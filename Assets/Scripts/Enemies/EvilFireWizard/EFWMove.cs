using UnityEngine;

public class EFWMove : State
{
    private EFWStateMachine stateMachine;
    private EntityMovement entityMovement;
    [SerializeField] private GameObject player; 
    public override void Enter()
    {
        stateMachine = GetComponent<EFWStateMachine>();
        entityMovement = GetComponent<EntityMovement>();
        
        stateMachine.anim.SetBool("isMoving", true);
    }

    public override void HandleInput()
    {
        
    }
    
    public override void LogicUpdate()
    {
        entityMovement.UpdateDirection();
        if (Mathf.Abs(transform.position.x - player.transform.position.x) > 10f)
        {
            entityMovement.enabled = false;
            stateMachine.ChangeState(stateMachine.idle);
        }
    }

    public override void Exit()
    {
        stateMachine.anim.SetBool("isMoving", false);
    }
}
