using UnityEngine;

public class RunShoot : State
{

    public override void Enter()
    {
        context.animator.SetBool("isRunning", true);
        context.animator.SetBool("isShooting", true);
    }

    public override void HandleInput()
    {
        if (!Input.GetKey(KeyCode.Mouse0)) // Ngừng bắn
        {
            context.ChangeState(context.run);
        }
    }

    public override void LogicUpdate()
    {
        // Logic vừa chạy vừa bắn
    }

    public override void Exit()
    {
        context.animator.SetBool("isRunning", false);
        context.animator.SetBool("isShooting", false);
    }
}

