using UnityEngine;

public class Shoot : State
{
    [SerializeField] private BulletSpawner bulletSpawner;
    private Vector2 bulletDirection;
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
        
    }

    public override void Exit()
    {
        context.animator.SetBool("isShooting", false);
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
}
