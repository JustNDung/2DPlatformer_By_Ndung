using UnityEngine;

public class Hurt : State
{
    public override void Enter()
    {
        context.animator.SetBool("isHurted", true);
    }

    public override void HandleInput()
    {
        
    }

    public override void LogicUpdate()
    {
        if (!context.playerController.isHurted) {
            context.ChangeState(context.idle);
        }
    }

    public override void Exit()
    {
        context.animator.SetBool("isHurted", false);
    }
}
