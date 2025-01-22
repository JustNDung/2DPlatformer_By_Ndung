using UnityEngine;

public class BODWalk : State
{
    private EntityMovement entityMovement;
    private BringerOfDeath bringerOfDeath;
    [SerializeField] private AttackCollider attackCollider;
    public override void Enter()
    {
        bringerOfDeath = GetComponent<BringerOfDeath>();
        entityMovement = GetComponent<EntityMovement>();
    }
    
    public override void Exit()
    {
        
    }

    public override void LogicUpdate()
    {
        if (attackCollider.target != null)
        {
            stateMachine.ChangeState(((BODStateMachine)stateMachine).bodAttack);
            entityMovement.enabled = false;
        }
        
        if (entityMovement.isPaused)
        {
            stateMachine.ChangeState(((BODStateMachine)stateMachine).bodIdle);
            entityMovement.enabled = false;
        }
    }

    public override void HandleInput()
    {
        
    }
}
