using UnityEngine;

public class RunShoot : State
{
    private Vector2 bulletDirection;
    [SerializeField] private BulletSpawner bulletSpawner;

    private PlayerStateMachine stateMachine;

    public override void Enter()
    {
        stateMachine = GetComponent<PlayerStateMachine>();
        stateMachine.animator.SetBool("isRunning", true);
        stateMachine.animator.SetBool("isShooting", true);
        Shooting();
    }

    public override void HandleInput()
    {
        if (!Input.GetKey(KeyCode.Mouse0)) // Ngừng bắn
        {
            stateMachine.ChangeState(stateMachine.run);
        }
    }

    public override void LogicUpdate()
    {
        
    }
    
    public void Shooting()
    {
        if (stateMachine.playerController.transform.rotation.y == 0) {
            bulletDirection = Vector2.right;
        } else {
            bulletDirection = Vector2.left;
        }
        bulletSpawner.SpawnBullet(bulletSpawner.transform.position, bulletDirection);
    }

    public override void Exit()
    {
        stateMachine.animator.SetBool("isRunning", false);
        stateMachine.animator.SetBool("isShooting", false);
    }
}

