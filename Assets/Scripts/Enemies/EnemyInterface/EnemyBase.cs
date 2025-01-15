using UnityEngine;
using System.Collections;

public abstract class EnemyBase : MonoBehaviour, IDamageable, IDeathable, IDamager
{
    protected Rigidbody2D rb;
    protected SpriteRenderer spriteRenderer;
    protected Animator animator;
    protected new Collider2D collider2D;

    /** Indicates how much damage the enemy deals **/
    public virtual float DamageAmount => 3f;
    
    protected float damageInterval;
    protected float maxHP;

    protected float currentHP;
    protected bool isDead = false;
    protected bool IsDead => isDead;
    protected Coroutine damageCoroutine;

    protected virtual void Awake()
    {
        collider2D = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private IEnumerator BlinkAndDestroy()
    {
        float blinkDuration = 1.5f; // Total blinking time
        float blinkInterval = 0.1f; // Interval between blinks
        float elapsedTime = 0f;

        while (elapsedTime < blinkDuration)
        {
            spriteRenderer.enabled = !spriteRenderer.enabled;
            elapsedTime += blinkInterval;
            yield return new WaitForSeconds(blinkInterval);
        }

        spriteRenderer.enabled = false;
        Destroy(gameObject); // Destroy the enemy object
    }

    public virtual void TakeDamage(float damage)
    {
        if (isDead) return; // No damage taken when already dead
        currentHP -= damage;

        if (currentHP <= 0)
        {
            Death();
        }
    }

    public virtual void DealDamage(IDamageable target)
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

    protected IEnumerator DealDamageOverTime(IDamageable target)
    {
        while (target != null)
        {
            target.TakeDamage(DamageAmount);
            yield return new WaitForSeconds(damageInterval);
        }

        damageCoroutine = null;
    }

    public virtual void Death()
    {
        if (isDead) return; // Prevent multiple calls
        isDead = true;
        
        if (TryGetComponent<EntityMovement>(out var movement))
        {
            movement.enabled = false;
        }

        // collider2D.enabled = false;
        rb.linearVelocity = Vector2.zero; // Stop all movement
        rb.bodyType = RigidbodyType2D.Kinematic;
        StartCoroutine(BlinkAndDestroy());
    }
}