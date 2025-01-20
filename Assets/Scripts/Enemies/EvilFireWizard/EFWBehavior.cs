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
}
