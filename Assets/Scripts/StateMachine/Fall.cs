using UnityEngine;

public class Fall : State
{
    public override void Enter()
    {
        context.animator.SetBool("isFalling", true);
    }

    public override void Exit()
    {
        context.animator.SetBool("isFalling", false);
    }

    public override void HandleInput()
    {
        
    }

    public override void LogicUpdate()
    {
        if (context.playerController.isGrounded) {
            context.ChangeState(context.idle);
        }
    }
}
