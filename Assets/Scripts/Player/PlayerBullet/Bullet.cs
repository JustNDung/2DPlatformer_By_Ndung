using UnityEngine;

public class Bullet : MonoBehaviour
{
    private GenericObjectPool<Bullet> pool;
    private Rigidbody2D rb;

    private void Awake()
    {
        // Lấy thành phần Rigidbody2D
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
    }

    public void SetPool(GenericObjectPool<Bullet> pool)
    {
        this.pool = pool;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Xử lý logic va chạm ở đây (ví dụ: gây sát thương)

        // Trả lại đạn về Pool
        ReturnToPool();
    }

    public void ReturnToPool()
    {
        // Dừng mọi chuyển động của đạn
        rb.linearVelocity = Vector2.zero;
        pool.Return(this);
    }

    public void Launch(Vector2 direction, float speed)
    {
        // Đặt lại vận tốc của Rigidbody2D để bắn đạn
        
        rb.linearVelocity = direction * speed;
        Debug.Log(direction.normalized);
    }

    private void OnDisable()
    {
        // Reset trạng thái nếu cần trước khi trả về Pool
        rb.linearVelocity = Vector2.zero;
    }
}
