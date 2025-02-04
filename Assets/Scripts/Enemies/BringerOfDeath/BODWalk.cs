using UnityEngine;

public class BODWalk : State
{
    private EntityMovement entityMovement;
    private BringerOfDeath bringerOfDeath;
    [SerializeField] private GameObject attackHitBox;
    [SerializeField] private GameObject castHitBox;
    public override void Enter()
    {
        bringerOfDeath = GetComponent<BringerOfDeath>();
        entityMovement = GetComponent<EntityMovement>();

        entityMovement.enabled = true;
    }
    
    public override void Exit()
    {
        
    }

    public override void LogicUpdate()
    {
        AttackCollider attackCollider = attackHitBox.GetComponent<AttackCollider>();
        CastCollider castCollider = castHitBox.GetComponent<CastCollider>();
        
        if (castCollider.enabled && castCollider.target != null)
        {
            entityMovement.enabled = false;
            stateMachine.ChangeState(((BODStateMachine)stateMachine).bodCast);
        }
        if (attackCollider.enabled && attackCollider.target != null)
        {
            entityMovement.enabled = false;
            stateMachine.ChangeState(((BODStateMachine)stateMachine).bodAttack);
        }
        if (entityMovement.isPaused)
        { 
            stateMachine.ChangeState(((BODStateMachine)stateMachine).bodIdle);
        }
    }

    public override void HandleInput()
    {
        
    }
}
