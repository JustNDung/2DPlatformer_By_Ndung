using UnityEngine;

public class BringerOfDeath : EnemyBase
{
    private BODStateMachine stateMachine;
    private BODWalk initialStateWalk;
    
    [SerializeField] private float attackDamage;
    [SerializeField] private float castDamage;
    [SerializeField] private AttackCollider _attackCollider;
    [SerializeField] private CastCollider _castCollider;

    public void BOFAttack()
    {
        _attackCollider.Attack();
    }

    public void BOFCast()
    {
        _castCollider.Cast();
    }

    private void Start()
    {
        stateMachine = GetComponent<BODStateMachine>();
        initialStateWalk = GetComponent<BODWalk>();
        stateMachine.ChangeState(initialStateWalk);
    }

    private void Update()
    {
        stateMachine.StateUpdate();
    }

    public override void DealDamage(IDamageable damageable)
    {
        if (damageable != null)
        {
            damageable.TakeDamage(attackDamage);
        }
    }
    
}
