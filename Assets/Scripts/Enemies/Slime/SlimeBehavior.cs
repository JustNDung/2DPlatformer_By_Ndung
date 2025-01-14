using UnityEngine;
using System.Collections;

public class SlimeBehavior : MonoBehaviour, IDamager, IDeathable, IDamageable
{
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private new Collider2D collider2D;
    public float DamageAmount => 3f;
    [SerializeField] float damageInterval = 0.5f;
    [SerializeField] float maxHP = 5f;
    private float currentHP;
    private Coroutine damageCoroutine;
    private bool isDead = false; // Cờ trạng thái để quản lý hành vi

    public bool IsDead => isDead;

    private void Awake()
    {
        currentHP = maxHP;
        collider2D = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private IEnumerator BlinkAndDestroy()
    {
        float blinkDuration = 1.5f; // Tổng thời gian nhấp nháy
        float blinkInterval = 0.1f; // Khoảng thời gian giữa mỗi lần nhấp nháy
        float elapsedTime = 0f;

        while (elapsedTime < blinkDuration)
        {
            spriteRenderer.enabled = !spriteRenderer.enabled;
            elapsedTime += blinkInterval;
            yield return new WaitForSeconds(blinkInterval);
        }

        spriteRenderer.enabled = false;
        Destroy(gameObject); // Phá hủy Slime
    }

    public void TakeDamage(float damage)
    {
        if (isDead) return; // Không nhận thêm sát thương khi đã chết
        currentHP -= damage;
        
        if (currentHP <= 0)
        {
            Death();
        }
    }

    public void DealDamage(IDamageable target)
    {
        if (target != null && damageCoroutine == null)
        {
            damageCoroutine = StartCoroutine(DealDamageOverTime(target));
        }
    }

    private IEnumerator DealDamageOverTime(IDamageable target)
    {
        while (target != null)
        {
            target.TakeDamage(DamageAmount);
            yield return new WaitForSeconds(damageInterval);
        }
        damageCoroutine = null;
    }

    public void Death()
    {
        if (isDead) return; // Tránh gọi nhiều lần
        isDead = true;

        // Gửi thông báo tới EntityMovement để dừng di chuyển
        if (TryGetComponent<EntityMovement>(out var movement))
        {
            movement.enabled = false;
        }

        rb.linearVelocity = Vector2.zero; // Dừng chuyển động
        rb.bodyType = RigidbodyType2D.Kinematic;
        StartCoroutine(BlinkAndDestroy());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isDead) return;

        if (collision.gameObject.CompareTag("Player"))
        {
            Transform playerTransform = collision.gameObject.transform;
            IDamageable player = collision.gameObject.GetComponent<IDamageable>();

            if (transform.DotTest(playerTransform, Vector2.up))
            {
                Death();
            }
            else if (player != null)
            {
                DealDamage(player);
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
