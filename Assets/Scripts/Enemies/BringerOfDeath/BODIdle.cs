using UnityEngine;

public class BODIdle : State
{
    private EntityMovement entityMovement;
    private BringerOfDeath bringerOfDeath;
    [SerializeField] private AttackCollider attackCollider;
    public override void Enter()
    {
        bringerOfDeath = gameObject.GetComponent<BringerOfDeath>();
        entityMovement = GetComponent<EntityMovement>();
        ((BODStateMachine)stateMachine).animator.SetBool("isIdling", true);
    }

    public override void Exit()
    {
        ((BODStateMachine)stateMachine).animator.SetBool("isIdling", false);
    }

    public override void LogicUpdate()
    {
        if (attackCollider.target != null)
        {
            stateMachine.ChangeState(((BODStateMachine)stateMachine).bodAttack);
        }
        
        if (!entityMovement.isPaused)
        { 
            stateMachine.ChangeState(((BODStateMachine)stateMachine).bodWalk);
            entityMovement.enabled = true;
        }
    }

    public override void HandleInput()
    {
        
    }
}
