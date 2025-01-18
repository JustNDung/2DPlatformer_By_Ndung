using UnityEngine;

public class EFWAttack : State
{
    private EFWStateMachine stateMachine;

    public override void Enter()
    {
        stateMachine = GetComponent<EFWStateMachine>();
        stateMachine.anim.SetBool("isAttacking", true);
    }
    
    public override void HandleInput()
    {
        
    }
    
    public override void LogicUpdate()
    {
        
    }
    
    public override void Exit()
    {
        stateMachine.anim.SetBool("isAttacking", false);
    }
}
