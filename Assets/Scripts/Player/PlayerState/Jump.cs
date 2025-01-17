using System.Runtime.InteropServices;
using Unity.Mathematics;
using UnityEngine;

public class Jump : State
{
    private PlayerStateMachine stateMachine;
    public override void Enter()
    {
        stateMachine = GetComponent<PlayerStateMachine>();
        stateMachine.animator.SetBool("isJumping", true);
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
        bool falling = stateMachine.playerController.isFalling;
        if (falling) {
            stateMachine.ChangeState(stateMachine.fall);
        }
    }
    public override void Exit()
    {
        stateMachine.animator.SetBool("isJumping", false);
    }
}
