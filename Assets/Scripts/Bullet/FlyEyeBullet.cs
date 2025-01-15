using UnityEngine;

public class FlyEyeBullet : BulletBase
{
    public override float DamageAmount => 7.5f;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb.linearVelocity = Vector2.zero;
        rb.bodyType = RigidbodyType2D.Kinematic;
        rb.gravityScale = 0f;
        // collide.enabled = false;
        // Trigger hit animation
        animator.SetTrigger("Hit");
        
        // if (isHit) return;
        isHit = true;
        IDamageable target = collision.gameObject.GetComponent<IDamageable>();
        
        if (target != null)
        {
            DealDamage(target); // Call TakeDamage on the target
        }
        
    }

    private void Update()
    {
        // Kiểm tra nếu animation "Hit" đã kết thúc
        if (isHit && IsAnimationComplete("shoot-hit-Animation"))
        {
            ReturnToPool();
        }
    }

    public override void Launch(Vector2 direction, float speed)
    {
        isHit = false;
        rb.linearVelocity = direction * speed;
    }

    private bool IsAnimationComplete(string animationName)
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        return stateInfo.IsName(animationName) && stateInfo.normalizedTime >= 1f;
    }
}
