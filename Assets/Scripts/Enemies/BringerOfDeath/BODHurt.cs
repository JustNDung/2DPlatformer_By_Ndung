using UnityEngine;

public class BODHurt : State
{
    public override void Enter()
    {
        ((BODStateMachine)stateMachine).animator.SetTrigger("Hurt");
    }
    
    public override void Exit()
    {
        
    }

    public override void LogicUpdate()
    {
        
    }

    public override void HandleInput()
    {
        
    }
}
