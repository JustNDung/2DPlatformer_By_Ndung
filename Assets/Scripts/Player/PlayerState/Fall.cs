using UnityEngine;

public class Fall : State
{
    private PlayerStateMachine stateMachine;
    public override void Enter()
    {
        stateMachine = GetComponent<PlayerStateMachine>();
        stateMachine.animator.SetBool("isFalling", true);
    }
    public override void Exit()
    {
        stateMachine.animator.SetBool("isFalling", false);
    }
    public override void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            stateMachine.ChangeState(stateMachine.shoot);
        }
    }
    public override void LogicUpdate()
    {
        if (stateMachine.playerController.isGrounded) {
            stateMachine.ChangeState(stateMachine.idle);
        }
    }
}
