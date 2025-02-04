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
        Debug.Log("Attacking");
    }

    public void BOFCast()
    {
        _castCollider.Cast();
        Debug.Log("Casting");
    }

    private void Start()
    {
        stateMachine = GetComponent<BODStateMachine>();
        initialStateWalk = GetComponent<BODWalk>();
        stateMachine.ChangeState(initialStateWalk);
        
        maxHP = 30;
        currentHP = maxHP;
    }

    private void Update()
    {
        stateMachine.StateUpdate();
    }

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        animator.SetTrigger("Hurt");
        
        stateMachine.ChangeState(stateMachine.bodWalk);
    }
    

    public override void DealDamage(IDamageable damageable)
    {
        if (damageable != null)
        {
            Debug.Log("Dealing Damage");
            damageable.TakeDamage(attackDamage);
        }
    }
    
    public override void Death()
    {
        if (isDead) return; // Prevent multiple calls
        isDead = true;
        
        if (TryGetComponent<EntityMovement>(out var movement))
        {
            movement.enabled = false;
        }
        
        collider2D.isTrigger = true;
        rb.linearVelocity = Vector2.zero; // Stop all movement
        rb.bodyType = RigidbodyType2D.Kinematic;
        animator.SetTrigger("Death");
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
    
    
}
