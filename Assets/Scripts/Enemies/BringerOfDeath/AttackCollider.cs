
using UnityEngine;

public class AttackCollider : HitBox
{
    [SerializeField] private BringerOfDeath bringerOfDeath;
    
    public void Attack()
    {
        Debug.Log("DealDamage");
        bringerOfDeath.DealDamage(target);
    }
}
