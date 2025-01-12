using UnityEngine;
using System.Collections;

public class SlimeBehavior : MonoBehaviour, IDamager, IDeathable
{
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    public float DamageAmount => 10f;
    [SerializeField] float damageInterval = 0.5f;
    private Coroutine damageCoroutine;
    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
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

    private IEnumerator DealDamageOverTime(IDamageable target)
    {
        while (target != null)
        {
            target.TakeDamage(DamageAmount);
            yield return new WaitForSeconds(damageInterval);
        }
    }

    public void Death()
    {
        StartCoroutine(BlinkAndDestroy());
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Kiểm tra va chạm với Player
        if (collision.gameObject.CompareTag("Player"))
        {
            Transform playerTransform = collision.gameObject.transform;

            if (transform.DotTest(playerTransform, Vector2.up))
            {
                Death();
            }
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
