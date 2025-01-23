using UnityEngine;

public class SpellCollider : HitBox
{
    [SerializeField] private BringerOfDeath bringerOfDeath;

    public void DealSpellDamage()
    {
        bringerOfDeath.DealDamage(target);
    }
    
}