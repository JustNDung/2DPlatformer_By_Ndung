using UnityEngine;

public class Run : State
{
    // private PlayerStateMachine stateMachine;
    public override void Enter()
    {
        // stateMachine = GetComponent<PlayerStateMachine>();
        ((PlayerStateMachine)stateMachine).animator.SetBool("isRunning", true);
    }

    public override void HandleInput()
    {
        // Xử lý input khi đang trong trạng thái "Run"
        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            stateMachine.ChangeState(((PlayerStateMachine)stateMachine).idle);
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            stateMachine.ChangeState(((PlayerStateMachine)stateMachine).jump);
        }
        else if (Input.GetKey(KeyCode.LeftControl))
        {
            stateMachine.ChangeState(((PlayerStateMachine)stateMachine).slide);
        }
        else if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) 
                && Input.GetKey(KeyCode.Mouse0))
        {
            stateMachine.ChangeState(((PlayerStateMachine)stateMachine).runShoot);
        }
    }

    public override void LogicUpdate()
    {
        
    }

    public override void Exit()
    {
        ((PlayerStateMachine)stateMachine).animator.SetBool("isRunning", false);  
    }

}
