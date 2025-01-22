
using UnityEngine;

public class AttackCollider : MonoBehaviour
{
    // public bool isAttacking;
    public IDamageable target;
    [SerializeField] private BringerOfDeath bringerOfDeath;

    private void Awake()
    {
        // isAttacking = false;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable damageable = collision.GetComponent<IDamageable>();
        if (damageable != null && collision.CompareTag("Player"))
        {
            // isAttacking = true;
            target = damageable;
        } 
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        IDamageable damageable = collision.GetComponent<IDamageable>();
        if (damageable != null && collision.CompareTag("Player"))
        {
            // isAttacking = false;
            target = null;
        }
    }

    public void Attack()
    {
        bringerOfDeath.DealDamage(target);
    }
}
