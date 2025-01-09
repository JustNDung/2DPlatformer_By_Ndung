using UnityEngine;

public class Shoot : State
{
    public override void Enter()
    {
        Debug.Log("Entering Shoot State");
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
        Debug.Log("Exiting Shoot State");
    }

    private void Shooting()
    {
        Debug.Log("Shooting a projectile!");
        // Triển khai logic bắn, ví dụ:
        // Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
    }
}
