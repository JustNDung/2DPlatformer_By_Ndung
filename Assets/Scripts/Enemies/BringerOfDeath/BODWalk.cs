using UnityEngine;

public class BODWalk : State
{
    private EntityMovement entityMovement;
    public override void Enter()
    {
        entityMovement = GetComponent<EntityMovement>();
    }
    
    public override void Exit()
    {
        
    }

    public override void LogicUpdate()
    {
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
