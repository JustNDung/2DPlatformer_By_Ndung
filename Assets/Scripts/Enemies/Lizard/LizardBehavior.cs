
using UnityEngine;
using System.Collections;

public class LizardBehavior : MonoBehaviour, IDamageable, IDamager, IImuneToStomp, IDeathable
{
    private Animator animator;
    private Rigidbody2D rb2d;
    private SpriteRenderer spriteRenderer;
    private Coroutine damageCoroutine;
    private Collider2D collider2D;
    [SerializeField] BulletSpawner bulletSpawner;
    public float DamageAmount => 6f;
    [SerializeField] float maxHP = 10f;
    [SerializeField] float currentHP;
    [SerializeField] float damageInterval = 0.5f;

    private void Awake()
    {
        collider2D = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        currentHP = maxHP;
    }

    public void TakeDamage(float damage)
    {
        currentHP -= damage;
    }

    public void DealDamage(IDamageable target)
    {
        if (target != null)
        {
            PlayerController player = target as PlayerController;
            if (player != null)
            {
                if (damageCoroutine == null)
                {
                    damageCoroutine = StartCoroutine(DealDamageOverTime(target));
                }
            }
        }
    }

    private void ShootFireBall()
    {
        animator.SetTrigger("Hit");
    }

    private void Update()
    {
        if (currentHP <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
        rb2d.bodyType = RigidbodyType2D.Kinematic; 
        rb2d.linearVelocity = Vector2.zero; 
        collider2D.enabled = false;
        StartCoroutine(BlinkAndDestroy());
    }
    
    private IEnumerator BlinkAndDestroy() {

        float blinkDuration = 1.5f; // Tổng thời gian nhấp nháy
        float blinkInterval = 0.1f; // Khoảng thời gian giữa mỗi lần nhấp nháy
        float elapsedTime = 0f;

        while (elapsedTime < blinkDuration) {
            // Chuyển đổi trạng thái hiển thị
            spriteRenderer.enabled = !spriteRenderer.enabled;

            elapsedTime += blinkInterval;
            yield return new WaitForSeconds(blinkInterval);
        }

        // Đảm bảo Slime ẩn hoàn toàn trước khi bị phá hủy
        spriteRenderer.enabled = false;

        // Phá hủy đối tượng Slime
        Destroy(gameObject);
    }

    private IEnumerator DealDamageOverTime(IDamageable target)
    {
        while (target != null)
        {
            target.TakeDamage(DamageAmount);
            yield return new WaitForSeconds(damageInterval);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && damageCoroutine != null)
        {
            StopCoroutine(damageCoroutine);
            damageCoroutine = null;
        }
    }
    
}
