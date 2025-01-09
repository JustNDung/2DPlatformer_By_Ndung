using UnityEngine;

public class Run : State
{
    public override void Enter()
    {
        context.animator.SetBool("isRunning", true);
    }

    public override void HandleInput()
    {
        // Xử lý input khi đang trong trạng thái "Run"
        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            context.ChangeState(context.idle);
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            context.ChangeState(context.jump);
        }
        else if (Input.GetKey(KeyCode.LeftControl))
        {
            context.ChangeState(context.slide);
        }
        else if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) 
                && Input.GetKey(KeyCode.Mouse0))
        {
            context.ChangeState(context.runShoot);
        }
    }

    public override void LogicUpdate()
    {
        
    }

    public override void Exit()
    {
        context.animator.SetBool("isRunning", false);  
    }

}
