using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class PlayerBullet : BulletBase
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isHit)
        {
            IDamageable target = collision.GetComponent<IDamageable>();
            if (target != null)
            {
                DealDamage(target);
            }
            isHit = true;
            
            rb.linearVelocity = Vector2.zero;
            rb.bodyType = RigidbodyType2D.Kinematic;
            collider.enabled = false;
            
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

    public override void Launch(Vector2 direction, float speed)
    {
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
    
}