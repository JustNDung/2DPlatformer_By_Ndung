using UnityEngine;

public class Slide : State
{
    public override void Enter()
    {
        context.animator.SetBool("isSliding", true);    
    }

    public override void HandleInput()
    {
        if (!Input.GetKey(KeyCode.LeftControl)) // Khi thả phím cúi
        {
            context.ChangeState(context.idle);
        }
    }

    public override void LogicUpdate()
    {
         
    }

    public override void Exit()
    {
        context.animator.SetBool("isSliding", false);
    }

}
