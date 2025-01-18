using UnityEngine;

public class EFWHurt : State
{
    private EFWStateMachine stateMachine;

    public override void Enter()
    {
        stateMachine = GetComponent<EFWStateMachine>();
        stateMachine.anim.SetTrigger("Hurt");
    }

    public override void HandleInput()
    {
        
    }
    
    public override void LogicUpdate()
    {
        
    }
    
    public override void Exit()
    {
        
    }
}
