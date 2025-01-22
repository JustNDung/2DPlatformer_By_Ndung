using UnityEngine;

public class BODAttack : State
{
    [SerializeField] private Collider2D attackCollider;
    public override void Enter()
    {
        ((BODStateMachine)stateMachine).animator.SetBool("isAttacking", true);
    }
    
    public override void Exit()
    {
        ((BODStateMachine)stateMachine).animator.SetBool("isAttacking", false);
    }

    public override void LogicUpdate()
    {
        
    }

    public override void HandleInput()
    {
        
    }
    
    
    
}
