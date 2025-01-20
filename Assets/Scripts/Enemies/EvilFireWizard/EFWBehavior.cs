using System.Collections;
using UnityEngine;

public class EFWBehavior : EnemyBase
{
    private EFWStateMachine stateMachine;

    public bool isAttacking;
    public bool isMoving;

    public override float DamageAmount => 4f;
    [SerializeField] private float attackCoolDown = 6f;
    [SerializeField] private float fireTime = 3f; // [ s]
    [SerializeField] private float hurtAnimation; // [ s]
    [SerializeField] private float deathAnimation;
    
    [SerializeField] private Collider2D physicCollider;
    [SerializeField] private Collider2D attackCollider;
    [SerializeField] private Collider2D attackZoneCollider;

    private Coroutine damageOverTimeCoroutine; // Biến kiểm soát coroutine

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        stateMachine = GetComponent<EFWStateMachine>();

        isAttacking = false;
        isMoving = false;

        maxHP = 30f;
        currentHP = maxHP;
        damageInterval = 0.5f;

        stateMachine.ChangeState(stateMachine.idle);
    }

    private void Update()
    {
        stateMachine.StateUpdate();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        IDamageable target = other.GetComponent<IDamageable>();

        if (target != null && other.CompareTag("Player"))
        {
            if (other.IsTouching(attackCollider))
            {
                // Chỉ bắt đầu coroutine mới nếu không có coroutine đang chạy
                isMoving = false;
                if (damageOverTimeCoroutine == null)
                {
                    damageOverTimeCoroutine = StartCoroutine(DealDamageCoroutine(target));
                }
            }
            else if (other.IsTouching(attackZoneCollider))
            {
                isAttacking = false;
                isMoving = true;
            }
        }
    }

    private IEnumerator DealDamageCoroutine(IDamageable target)
    {
        isAttacking = true;
        isMoving = false;
        DealDamage(target);
        yield return new WaitForSeconds(fireTime);
        StopCoroutine(damageCoroutine);
        isAttacking = false;
        yield return new WaitForSeconds(attackCoolDown);
        damageOverTimeCoroutine = null;
        damageCoroutine = null;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        isAttacking = false;
        isMoving = false;
    }

    public override void TakeDamage(float damage)
    {
        if (isDead) return; // No damage taken when already dead
        
        currentHP -= damage;

        if (currentHP <= 0)
        {
            Death();
        }
        else
        {
            isHurt = true;
            StartCoroutine(ResetHurtState());
        }
    }
    
    private IEnumerator ResetHurtState()
    {
        animator.SetTrigger("Hurt");
        yield return new WaitForSeconds(hurtAnimation); // Thời gian chờ trước khi cho phép nhận sát thương lần nữa
        isHurt = false;
    }

    public override void Death()
    {
        if (isDead) return; // Prevent multiple calls
        animator.SetTrigger("Dead");
        isDead = true;
        
        if (TryGetComponent<EntityMovement>(out var movement))
        {
            movement.enabled = false;
        }

        collider2D.isTrigger = true;
        rb.linearVelocity = Vector2.zero; // Stop all movement
        rb.bodyType = RigidbodyType2D.Kinematic;
        StartCoroutine(DeathAnimation());
    }

    private IEnumerator DeathAnimation()
    {
        yield return new WaitForSeconds(deathAnimation);
        Destroy(gameObject);
    }
}
