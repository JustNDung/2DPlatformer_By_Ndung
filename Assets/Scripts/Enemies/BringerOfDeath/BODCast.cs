using UnityEngine;

public class BODCast : State
{
    [SerializeField] private Collider2D castCollider;
    public override void Enter()
    {
        ((BODStateMachine)stateMachine).animator.SetBool("isCasting", true);
    }
    
    public override void Exit()
    {
        ((BODStateMachine)stateMachine).animator.SetBool("isCasting", false);
    }

    public override void LogicUpdate()
    {
        
    }

    public override void HandleInput()
    {
        
    }
}
