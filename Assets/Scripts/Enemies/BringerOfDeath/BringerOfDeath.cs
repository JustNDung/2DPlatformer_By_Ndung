using UnityEngine;

public class BringerOfDeath : EnemyBase
{
    private BODStateMachine stateMachine;
    private BODWalk initialStateWalk;
    
    [SerializeField] private float attackDamage;
    [SerializeField] private float castDamage;
    [SerializeField] private AttackCollider _attackCollider;

    public void BOFAttack()
    {
        _attackCollider.Attack();
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
