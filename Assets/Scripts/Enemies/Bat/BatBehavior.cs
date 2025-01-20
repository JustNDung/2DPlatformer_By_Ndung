
using UnityEngine;
using System.Collections;

public class BatBehavior : EnemyBase
{
    private Transform target; // Người chơi bị phát hiện

    [SerializeField] private float damageDuration = 2f; // Thời gian gây sát thương
    [SerializeField] private float totalDamage = 25f;  // Tổng sát thương gây ra trong damageDuration
    [SerializeField] private float attackSpeed = 5f; // Tốc độ lao tới
    [SerializeField] private float attackInterval = 7f; // Khoảng thời gian giữa các lần tấn công

    private Coroutine attackCoroutine; // Coroutine tấn công
    private Coroutine damageDurationCoroutine;

    [SerializeField] private Collider2D batCollider;
    [SerializeField] private Collider2D batTriggerCollider;

    private void Start()
    {
        maxHP = 10f;
        currentHP = maxHP;
        damageInterval = 0.5f;
        isDead = false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        IDamageable idamageable = other.GetComponent<IDamageable>();
        if (other.CompareTag("Player") && idamageable != null)
        {
            target = other.transform;
        }
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        IDamageable idamageable = other.gameObject.GetComponent<IDamageable>();
        if (other.gameObject.CompareTag("Player") && idamageable != null && damageDurationCoroutine == null)
        {
            damageDurationCoroutine = StartCoroutine(DamageDuringDuration(idamageable, damageDuration, totalDamage));
            rb.linearVelocity = Vector2.zero;
        }
    }
    
    private void OnCollisionExit2D(Collision2D other)
    {
        IDamageable idamageable = other.gameObject.GetComponent<IDamageable>();
        if (other.gameObject.CompareTag("Player") && idamageable != null)
        {
            StopCoroutine(DamageDuringDuration(idamageable, damageDuration, totalDamage));
            damageDurationCoroutine = null;
        }
    }

    
    private void OnTriggerExit2D(Collider2D other)
    {
        IDamageable idamageable = other.GetComponent<IDamageable>();
        if (idamageable != null && other.CompareTag("Player"))
        {
            target = null;
            if (attackCoroutine != null)
            {
                StopCoroutine(attackCoroutine);
                attackCoroutine = null;
            }
        }
    }

    private void FixedUpdate()
    {
        if (attackCoroutine == null)
        {
            StartCoroutine(Attack());
        }
    }

    private IEnumerator Attack()
    {
        while (target != null)
        {
            MoveTowardsTarget();
            yield return new WaitForSeconds(attackInterval);
        }

        attackCoroutine = null;
    }

    private void MoveTowardsTarget()
    {
        // Lấy hướng di chuyển
        Vector2 currentPosition = rb.position;
        Vector2 targetPosition = target.position;

        if (targetPosition.x < currentPosition.x)
        {
            transform.eulerAngles = Vector3.zero;
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        // Tính toán vị trí mới dựa trên tốc độ và thời gian
        Vector2 newPosition = Vector2.MoveTowards(currentPosition, targetPosition, attackSpeed * Time.fixedDeltaTime);
        // Di chuyển Rigidbody
        rb.MovePosition(newPosition);
    }
    
    private IEnumerator DamageDuringDuration(IDamageable idamgeable, float duration, float totalDamage)
    {
        float elapsed = 0f;
        float damagePerSecond = totalDamage / duration; // Sát thương mỗi giây

        while (elapsed < duration)
        {
            float deltaTime = Time.deltaTime; // Thời gian mỗi khung hình
            float damageThisFrame = damagePerSecond * deltaTime; // Sát thương trong khung hình này

            if (idamgeable != null)
            {
                idamgeable.TakeDamage(damageThisFrame);
            }

            elapsed += deltaTime; // Cập nhật thời gian đã trôi qua
            yield return null;    // Chờ đến khung hình tiếp theo
        }
        damageDurationCoroutine = null;
    }
}
