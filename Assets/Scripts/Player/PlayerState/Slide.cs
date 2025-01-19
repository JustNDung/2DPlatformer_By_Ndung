using UnityEngine;

public class Slide : State
{
    // private PlayerStateMachine stateMachine;
    public override void Enter()
    {
        // stateMachine = GetComponent<PlayerStateMachine>();
        ((PlayerStateMachine)stateMachine).animator.SetBool("isSliding", true);    
    }

    public override void HandleInput()
    {
        if (!Input.GetKey(KeyCode.LeftControl)) // Khi thả phím cúi
        {
            stateMachine.ChangeState(((PlayerStateMachine)stateMachine).idle);
        }
    }

    public override void LogicUpdate()
    {
         
    }

    public override void Exit()
    {
        ((PlayerStateMachine)stateMachine).animator.SetBool("isSliding", false);
    }

}
