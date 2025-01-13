using UnityEngine;

public class Bullet : MonoBehaviour
{
    private GenericObjectPool<Bullet> pool;
    private Rigidbody2D rb;
    private Animator animator;

    private bool isHit = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
    }

    public void SetPool(GenericObjectPool<Bullet> pool)
    {
        this.pool = pool;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isHit)
        {
            isHit = true;
            
            rb.linearVelocity = Vector2.zero;
            rb.bodyType = RigidbodyType2D.Kinematic;
            GetComponent<Collider2D>().enabled = false;
            
            animator.SetTrigger("Hit");
        }
    }

    private void Update()
    {
        // Kiểm tra nếu animation "Hit" đã kết thúc
        if (isHit && IsAnimationComplete("Bullet_Hit_Animation"))
        {
            ReturnToPool();
        }
    }

    public void ReturnToPool()
    {
        // Đặt lại trạng thái
        isHit = false;
        gameObject.SetActive(false);

        rb.linearVelocity = Vector2.zero;
        GetComponent<Collider2D>().enabled = true;
        rb.bodyType = RigidbodyType2D.Dynamic;
        
        pool.Return(this);
    }

    public void Launch(Vector2 direction, float speed)
    {
        // Đặt lại trạng thái khi bắn
        isHit = false;
        if (direction == Vector2.right)
        {
            transform.eulerAngles = Vector3.zero;
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        rb.linearVelocity = direction * speed;
    }

    private bool IsAnimationComplete(string animationName)
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        return stateInfo.IsName(animationName) && stateInfo.normalizedTime >= 1f;
    }

    private void OnDisable()
    {
        // Reset trạng thái khi bị tắt
        rb.linearVelocity = Vector2.zero;
    }
}
