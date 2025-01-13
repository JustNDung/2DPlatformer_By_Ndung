using UnityEngine;

public class RunShoot : State
{
    private Vector2 bulletDirection;
    [SerializeField] private BulletSpawner bulletSpawner;

    public override void Enter()
    {
        context.animator.SetBool("isRunning", true);
        context.animator.SetBool("isShooting", true);
        Shooting();
    }

    public override void HandleInput()
    {
        if (!Input.GetKey(KeyCode.Mouse0)) // Ngừng bắn
        {
            context.ChangeState(context.run);
        }
    }

    public override void LogicUpdate()
    {
        
    }
    
    public void Shooting()
    {
        if (context.playerController.transform.rotation.y == 0) {
            bulletDirection = Vector2.right;
        } else {
            bulletDirection = Vector2.left;
        }
        bulletSpawner.SpawnBullet(bulletSpawner.transform.position, bulletDirection);
    }

    public override void Exit()
    {
        context.animator.SetBool("isRunning", false);
        context.animator.SetBool("isShooting", false);
    }
}

