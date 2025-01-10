using UnityEngine;

public class Shoot : State
{
    public override void Enter()
    {
        context.animator.SetBool("isShooting", true);  
        Shooting(); 
    }

    public override void HandleInput()
    {
        if (!Input.GetKey(KeyCode.Mouse0)) // Khi người chơi thả phím bắn
        {
            context.ChangeState(context.idle);
        }
    }

    public override void LogicUpdate()
    {
        // Giữ trạng thái bắn nếu cần (ví dụ: bắn liên tục nếu giữ phím)
    }

    public override void Exit()
    {
        context.animator.SetBool("isShooting", false);
    }

    private void Shooting()
    {
        
    }
}
