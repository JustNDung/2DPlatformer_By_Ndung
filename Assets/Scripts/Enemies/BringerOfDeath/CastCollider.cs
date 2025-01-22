using UnityEngine;

public class CastCollider : HitBox
{
    [SerializeField] private BringerOfDeath bringerOfDeath;

    public void Cast()
    {
        bringerOfDeath.DealDamage(target);
    }
}
