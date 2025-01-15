using UnityEngine;
public class SlimeBehavior : EnemyBase
{
    private void Start()
    {
        maxHP = 5f;
        currentHP = maxHP;
        damageInterval = 0.5f;
        isDead = false;
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
