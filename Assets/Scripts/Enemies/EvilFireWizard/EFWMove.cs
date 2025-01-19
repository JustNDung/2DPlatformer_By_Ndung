using UnityEngine;

public class EFWMove : State
{
    // private EFWStateMachine stateMachine;
    private EntityMovement entityMovement;
    private EFWBehavior behavior;
    [SerializeField] private GameObject player; 
    public override void Enter()
    {
        // stateMachine = GetComponent<EFWStateMachine>();
        entityMovement = GetComponent<EntityMovement>();
        behavior = GetComponent<EFWBehavior>();
        
        ((EFWStateMachine)stateMachine).anim.SetBool("isMoving", true);
    }

    public override void HandleInput()
    {
        
    }
    
    public override void LogicUpdate()
    {
        entityMovement.UpdateDirection();
        if (!behavior.isAttacking && !behavior.isMoving)
        {
            stateMachine.ChangeState(((EFWStateMachine)stateMachine).idle);
        }
        else if (behavior.isAttacking)
        {
            stateMachine.ChangeState(((EFWStateMachine)stateMachine).attack);
        }
    }

    public override void Exit()
    {
        entityMovement.enabled = false;
        ((EFWStateMachine)stateMachine).anim.SetBool("isMoving", false);
    }
}
