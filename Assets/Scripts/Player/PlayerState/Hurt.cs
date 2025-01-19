
public class Hurt : State
{
    // private PlayerStateMachine stateMachine;
    public override void Enter()
    {
        // stateMachine = GetComponent<PlayerStateMachine>();
        ((PlayerStateMachine)stateMachine).animator.SetBool("isHurted", true);
    }
    public override void HandleInput()
    {
        
    }
    public override void LogicUpdate()
    {
        if (!((PlayerStateMachine)stateMachine).playerController.isHurted) {
            stateMachine.ChangeState(((PlayerStateMachine)stateMachine).idle);
        }
    }
    public override void Exit()
    {
        ((PlayerStateMachine)stateMachine).animator.SetBool("isHurted", false);
    }
}
