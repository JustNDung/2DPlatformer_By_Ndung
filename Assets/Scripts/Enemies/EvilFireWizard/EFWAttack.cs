using UnityEngine;

public class EFWAttack : State
{
    private EFWBehavior behavior;

    public override void Enter()
    {
        behavior = GetComponent<EFWBehavior>();
        
        ((EFWStateMachine)stateMachine).anim.SetBool("isAttacking", true);
    }
    
    public override void HandleInput()
    {
        
    }
    
    public override void LogicUpdate()
    {
        if (!behavior.isAttacking)
        {
            ((EFWStateMachine)stateMachine).ChangeState(((EFWStateMachine)stateMachine).idle);
        }
    }
    
    public override void Exit()
    {
        ((EFWStateMachine)stateMachine).anim.SetBool("isAttacking", false);
    }
}
