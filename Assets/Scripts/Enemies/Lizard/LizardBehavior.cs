
using UnityEngine;
using System.Collections;

public class LizardBehavior : EnemyBase
{
    private Coroutine shootCoroutine;
    [SerializeField] private float fireballInterval = 2f;
    [SerializeField] private BulletSpawner bulletSpawner;
    
    private void Start()
    {
        maxHP = 10f;
        currentHP = maxHP;
        damageInterval = 0.5f;
        isDead = false;
        shootCoroutine = StartCoroutine(ShootFireballRoutine());
    }

    private void OnDisable()
    {
        if (shootCoroutine != null)
        {
            StopCoroutine(shootCoroutine);
            shootCoroutine = null;
        }
    }
    private void ShootFireBall()
    {
        animator.SetBool("isShooting", true);
        if (bulletSpawner != null)
        {
            bulletSpawner.SpawnBullet(bulletSpawner.transform.position, Vector2.left);
        }
        else
        {
            Debug.LogError("BulletSpawner is missing!");
        }
    }

    private IEnumerator ShootFireballRoutine()
    {
        while (true)
        {
            ShootFireBall();
            yield return new WaitForSeconds(0.03f);
            animator.SetBool("isShooting", false);
            yield return new WaitForSeconds(fireballInterval);
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
