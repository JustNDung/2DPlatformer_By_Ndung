using UnityEngine;
using System.Collections;

public class FlyEyeBehavior : EnemyBase
{
    private Coroutine shootCoroutine;
    [SerializeField] private float flyeyeBulletInterval = 3f;
    [SerializeField] private BulletSpawner bulletSpawner;
    
    private void Start()
    {
        maxHP = 5f;
        currentHP = maxHP;
        damageInterval = 0.5f;
        isDead = false;
        shootCoroutine = StartCoroutine(ShootFlyeyeBulletRoutine());
    }

    private void OnDisable()
    {
        if (shootCoroutine != null)
        {
            StopCoroutine(shootCoroutine);
            shootCoroutine = null;
        }
    }
    private void ShootFlyEyeBullet()
    {
            // Tính hướng từ FlyEye đến Player
            Vector2 directionToPlayer = GameManager.Instance.playerController.transform.position - transform.position;
            directionToPlayer.Normalize();

            if (directionToPlayer.x < 0)
            {
                spriteRenderer.flipX = false;
            }
            else
            {
                spriteRenderer.flipX = true;
            }
            // Tính vị trí mới của BulletSpawner
            Vector2 spawnerPosition = (Vector2)transform.position + directionToPlayer * 1.5f;
            // Đặt BulletSpawner tại vị trí mới
            if (bulletSpawner != null)
            {
                bulletSpawner.transform.position = spawnerPosition;
                // Bắn đạn từ vị trí mới
                bulletSpawner.SpawnBullet(bulletSpawner.transform.position, directionToPlayer);
            }
            else
            {
                Debug.LogError("Current BulletSpawner is missing!");
            }
    }
    
    private IEnumerator ShootFlyeyeBulletRoutine()
    {
        while (true)
        {
            ShootFlyEyeBullet();
            yield return new WaitForSeconds(flyeyeBulletInterval);
        }
    }

    public override void Death()
    {
        base.Death();
        StopCoroutine(shootCoroutine);
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();
            if (damageable != null)
            {
                DealDamage(damageable);
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
