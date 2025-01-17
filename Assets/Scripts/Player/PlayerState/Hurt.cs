
public class Hurt : State
{
    private PlayerStateMachine stateMachine;
    public override void Enter()
    {
        stateMachine = GetComponent<PlayerStateMachine>();
        stateMachine.animator.SetBool("isHurted", true);
    }
    public override void HandleInput()
    {
        
    }
    public override void LogicUpdate()
    {
        if (!stateMachine.playerController.isHurted) {
            stateMachine.ChangeState(stateMachine.idle);
        }
    }
    public override void Exit()
    {
        stateMachine.animator.SetBool("isHurted", false);
    }
}
