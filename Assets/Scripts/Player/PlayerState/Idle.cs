using UnityEngine;

public class Idle : State
{
    // private PlayerStateMachine stateMachine;
    public override void Enter()
    {
        // stateMachine = GetComponent<PlayerStateMachine>();
    }
    public override void HandleInput()
    {

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            stateMachine.ChangeState(((PlayerStateMachine)stateMachine).run);
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            stateMachine.ChangeState(((PlayerStateMachine)stateMachine).jump);
        }
        else if (Input.GetKey(KeyCode.C))
        {
            stateMachine.ChangeState(((PlayerStateMachine)stateMachine).duck);
        }
        else if (Input.GetKey(KeyCode.Mouse0))
        {
            stateMachine.ChangeState(((PlayerStateMachine)stateMachine).shoot);
        }
        else if (Input.GetKey(KeyCode.LeftControl))
        {
            stateMachine.ChangeState(((PlayerStateMachine)stateMachine).slide);
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
