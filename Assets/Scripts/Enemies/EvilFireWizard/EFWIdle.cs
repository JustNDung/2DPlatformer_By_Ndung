using UnityEngine;

public class EFWIdle : State
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
        // entityMovement.enabled = false;
        Debug.Log("Idle");
    }

    public override void HandleInput()
    {
        
    }

    public override void LogicUpdate()
    {
        if (!behavior.isAttacking && behavior.isMoving)
        {
            entityMovement.enabled = true;
            stateMachine.ChangeState(((EFWStateMachine)stateMachine).move);
        }
        else if (behavior.isAttacking)
        {
            entityMovement.enabled = false;
            stateMachine.ChangeState(((EFWStateMachine)stateMachine).attack);
        }
    }
    public override void Exit()
    {
        
    }
}
