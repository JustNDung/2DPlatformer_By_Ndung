using UnityEngine;

public class BODIdle : State
{
    private EntityMovement entityMovement;
    [SerializeField] private GameObject attackHitBox;
    [SerializeField] private GameObject castHitBox;
    public override void Enter()
    {
        entityMovement = GetComponent<EntityMovement>();
        ((BODStateMachine)stateMachine).animator.SetBool("isIdling", true);
    }

    public override void Exit()
    {
        ((BODStateMachine)stateMachine).animator.SetBool("isIdling", false);
    }

    public override void LogicUpdate()
    {
        AttackCollider attackCollider = attackHitBox.GetComponent<AttackCollider>();
        CastCollider castCollider = castHitBox.GetComponent<CastCollider>();
        
        if (castCollider.enabled && castCollider.target != null)
        {
            entityMovement.enabled = false;
            stateMachine.ChangeState(((BODStateMachine)stateMachine).bodCast);
        }
        if (attackCollider.enabled && attackCollider.target != null)
        {
            entityMovement.enabled = false;
            stateMachine.ChangeState(((BODStateMachine)stateMachine).bodAttack);
        }
        if (!entityMovement.isPaused)
        { 
            stateMachine.ChangeState(((BODStateMachine)stateMachine).bodWalk);
        }
    }

    public override void HandleInput()
    {
        
    }
}
