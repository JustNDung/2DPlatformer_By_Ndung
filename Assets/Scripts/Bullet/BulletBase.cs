using UnityEngine;

public abstract class BulletBase : MonoBehaviour, IDamager
{
    protected GenericObjectPool<BulletBase> bulletPool;
    protected Animator animator;
    protected Rigidbody2D rb;
    protected Collider2D collide;
    protected bool isHit;
    public float DamageAmount => 5f;

    private void Awake()
    {
        collide = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
        
        isHit = false;
    }
    public void SetPool(GenericObjectPool<BulletBase> pool)
    {
        this.bulletPool = pool;
    }

    public abstract void Launch(Vector2 direction, float speed);
    
    public void ReturnToPool()
    {
        // Đặt lại trạng thái
        isHit = false;
        gameObject.SetActive(false);

        rb.linearVelocity = Vector2.zero;
        collide.enabled = true;
        rb.bodyType = RigidbodyType2D.Dynamic;
        
        bulletPool.Return(this);
    }
    
    public void DealDamage(IDamageable target)
    {
        if (target != null)
        {
            target.TakeDamage(DamageAmount);
        }
    }

    public void OnDisable()
    {
        // Reset trạng thái khi bị tắt
        isHit = false;
        rb.linearVelocity = Vector2.zero;
    }

}