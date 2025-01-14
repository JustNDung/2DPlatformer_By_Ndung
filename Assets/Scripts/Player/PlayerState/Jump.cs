using System.Runtime.InteropServices;
using Unity.Mathematics;
using UnityEngine;

public class Jump : State
{
    public override void Enter()
    {
        context.animator.SetBool("isJumping", true);
    }
    public override void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            context.ChangeState(context.shoot);
        }
    }
    public override void LogicUpdate()
    {
        bool falling = context.playerController.isFalling;
        if (falling) {
            context.ChangeState(context.fall);
        }
    }
    public override void Exit()
    {
        context.animator.SetBool("isJumping", false);
    }
}
