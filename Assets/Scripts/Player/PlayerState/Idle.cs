using UnityEngine;

public class Idle : State
{
    public override void Enter()
    {

    }
    public override void HandleInput()
    {

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            context.ChangeState(context.run);
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            context.ChangeState(context.jump);
        }
        else if (Input.GetKey(KeyCode.C))
        {
            context.ChangeState(context.duck);
        }
        else if (Input.GetKey(KeyCode.Mouse0))
        {
            context.ChangeState(context.shoot);
        }
        else if (Input.GetKey(KeyCode.LeftControl))
        {
            context.ChangeState(context.slide);
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
