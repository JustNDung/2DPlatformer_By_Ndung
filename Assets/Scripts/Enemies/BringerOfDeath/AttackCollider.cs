
using UnityEngine;

public class AttackCollider : HitBox
{
    [SerializeField] private BringerOfDeath bringerOfDeath;

    private void OnDisable()
    {
        target = null;
    }
    public void Attack()
    {
        Debug.Log("DealDamage");
        bringerOfDeath.DealDamage(target);
    }
}
