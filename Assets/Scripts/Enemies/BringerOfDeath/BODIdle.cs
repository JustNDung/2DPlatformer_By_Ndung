using UnityEngine;

public class BODIdle : State
{
    private EntityMovement entityMovement;
    private BringerOfDeath bringerOfDeath;
    [SerializeField] private AttackCollider attackCollider;
    [SerializeField] private CastCollider castCollider;
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
        if (castCollider.target != null)
        {
            entityMovement.enabled = false;
            stateMachine.ChangeState(((BODStateMachine)stateMachine).bodCast);
        }
        if (attackCollider.target != null)
        {
            entityMovement.enabled = false;
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
