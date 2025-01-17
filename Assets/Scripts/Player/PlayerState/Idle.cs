using UnityEngine;

public class Idle : State
{
    private PlayerStateMachine stateMachine;
    public override void Enter()
    {
        stateMachine = GetComponent<PlayerStateMachine>();
    }
    public override void HandleInput()
    {

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            stateMachine.ChangeState(stateMachine.run);
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            stateMachine.ChangeState(stateMachine.jump);
        }
        else if (Input.GetKey(KeyCode.C))
        {
            stateMachine.ChangeState(stateMachine.duck);
        }
        else if (Input.GetKey(KeyCode.Mouse0))
        {
            stateMachine.ChangeState(stateMachine.shoot);
        }
        else if (Input.GetKey(KeyCode.LeftControl))
        {
            stateMachine.ChangeState(stateMachine.slide);
        }   
    }
    public override void LogicUpdate()
    {
        // Logic Idle
    }
    public override void Exit()
    {

    }
}
