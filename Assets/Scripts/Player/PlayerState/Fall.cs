using UnityEngine;

public class Fall : State
{
    // private PlayerStateMachine stateMachine;
    public override void Enter()
    {
        // stateMachine = GetComponent<PlayerStateMachine>();
        ((PlayerStateMachine)stateMachine).animator.SetBool("isFalling", true);
    }
    public override void Exit()
    {
        ((PlayerStateMachine)stateMachine).animator.SetBool("isFalling", false);
    }
    public override void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            stateMachine.ChangeState(((PlayerStateMachine)stateMachine).shoot);
        }
    }
    public override void LogicUpdate()
    {
        if (((PlayerStateMachine)stateMachine).playerController.isGrounded) {
            stateMachine.ChangeState(((PlayerStateMachine)stateMachine).idle);
        }
    }
}
