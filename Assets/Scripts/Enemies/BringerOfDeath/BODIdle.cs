using UnityEngine;

public class BODIdle : State
{
    private EntityMovement entityMovement;
    public override void Enter()
    {
        Debug.Log("BOD Idle Enter");
        entityMovement = GetComponent<EntityMovement>();
        ((BODStateMachine)stateMachine).animator.SetBool("isIdling", true);
    }

    public override void Exit()
    {
        ((BODStateMachine)stateMachine).animator.SetBool("isIdling", false);
    }

    public override void LogicUpdate()
    {
        Debug.Log(entityMovement.isPaused);
        if (!entityMovement.isPaused)
        { 
            stateMachine.ChangeState(((BODStateMachine)stateMachine).bodWalk);
            entityMovement.enabled = true;
        }
    }

    public override void HandleInput()
    {
        
    }
}
