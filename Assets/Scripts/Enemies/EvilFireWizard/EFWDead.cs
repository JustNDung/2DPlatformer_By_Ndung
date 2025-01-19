using UnityEngine;

public class EFWDead : State
{
    // private EFWStateMachine stateMachine;
    public override void Enter()
    {
        // stateMachine = GetComponent<EFWStateMachine>();
        ((EFWStateMachine)stateMachine).anim.SetTrigger("Dead");
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
