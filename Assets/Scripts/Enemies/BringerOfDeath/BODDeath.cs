using UnityEngine;

public class BODDeath : State
{
    public override void Enter()
    {
        ((BODStateMachine)stateMachine).animator.SetTrigger("Death");
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
