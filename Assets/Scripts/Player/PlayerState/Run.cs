using UnityEngine;

public class Run : State
{
    private PlayerStateMachine stateMachine;
    public override void Enter()
    {
        stateMachine = GetComponent<PlayerStateMachine>();
        stateMachine.animator.SetBool("isRunning", true);
    }

    public override void HandleInput()
    {
        // Xử lý input khi đang trong trạng thái "Run"
        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            stateMachine.ChangeState(stateMachine.idle);
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            stateMachine.ChangeState(stateMachine.jump);
        }
        else if (Input.GetKey(KeyCode.LeftControl))
        {
            stateMachine.ChangeState(stateMachine.slide);
        }
        else if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) 
                && Input.GetKey(KeyCode.Mouse0))
        {
            stateMachine.ChangeState(stateMachine.runShoot);
        }
    }

    public override void LogicUpdate()
    {
        
    }

    public override void Exit()
    {
        stateMachine.animator.SetBool("isRunning", false);  
    }

}
