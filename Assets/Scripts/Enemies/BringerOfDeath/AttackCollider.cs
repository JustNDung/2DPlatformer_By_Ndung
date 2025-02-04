
using UnityEngine;

public class AttackCollider : HitBox
{
    [SerializeField] private BringerOfDeath bringerOfDeath;
    
    public void Attack()
    {
        bringerOfDeath.DealDamage(target);
    }
}
