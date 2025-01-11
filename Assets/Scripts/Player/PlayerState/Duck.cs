using UnityEngine;

public class Duck : State
{
    public override void Enter()
    {
        context.animator.SetTrigger("Duck");
    }

    public override void HandleInput()
    {
        if (!Input.GetKey(KeyCode.C))
        {
            context.ChangeState(context.idle);
        }
    }

    public override void LogicUpdate()
    {
        // Logic cúi
    }

    public override void Exit()
    {
        context.animator.ResetTrigger("Duck");
    }
}
