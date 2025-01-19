using UnityEngine;

public class Shoot : State
{
    [SerializeField] private BulletSpawner bulletSpawner;
    private Vector2 bulletDirection;
    // private PlayerStateMachine stateMachine;
    public override void Enter()
    {
        // stateMachine = GetComponent<PlayerStateMachine>();
        ((PlayerStateMachine)stateMachine).animator.SetBool("isShooting", true);  
        Shooting(); 
    }

    public override void HandleInput()
    {
        if (!Input.GetKey(KeyCode.Mouse0)) // Khi người chơi thả phím bắn
        {
            stateMachine.ChangeState(((PlayerStateMachine)stateMachine).idle);
        }
    }

    public override void LogicUpdate()
    {
        
    }

    public override void Exit()
    {
        ((PlayerStateMachine)stateMachine).animator.SetBool("isShooting", false);
    }

    public void Shooting()
    {
        if (((PlayerStateMachine)stateMachine).playerController.transform.rotation.y == 0) {
            bulletDirection = Vector2.right;
        } else {
            bulletDirection = Vector2.left;
        }
        bulletSpawner.SpawnBullet(bulletSpawner.transform.position, bulletDirection);
    }
}
