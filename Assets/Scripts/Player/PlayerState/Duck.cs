using UnityEngine;

public class Duck : State
{
    private PlayerStateMachine stateMachine;
    public override void Enter()
    {
        stateMachine = GetComponent<PlayerStateMachine>();
        stateMachine.animator.SetTrigger("Duck");
    }
    public override void HandleInput()
    {
        if (!Input.GetKey(KeyCode.C))
        {
            stateMachine.ChangeState(stateMachine.idle);
        }
    }
    public override void LogicUpdate()
    {
        // Logic cúi
    }
    public override void Exit()
    {
        stateMachine.animator.ResetTrigger("Duck");
    }
}
