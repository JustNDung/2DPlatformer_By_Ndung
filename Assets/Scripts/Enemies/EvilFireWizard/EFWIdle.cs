using UnityEngine;

public class EFWIdle : State
{
    private EFWStateMachine stateMachine;
    private EntityMovement entityMovement;
    [SerializeField] private GameObject player;
    
    public override void Enter()
    {
        stateMachine = GetComponent<EFWStateMachine>();
        entityMovement = GetComponent<EntityMovement>();
        // entityMovement.enabled = false;
        Debug.Log("Idle");
    }

    public override void HandleInput()
    {
        
    }

    public override void LogicUpdate()
    {
        if(Mathf.Abs(transform.position.x - player.transform.position.x) <= 10f)
        {
            entityMovement.enabled = true;
            stateMachine.ChangeState(stateMachine.move);
        }
    }
    
    public override void Exit()
    {
        
    }
}
