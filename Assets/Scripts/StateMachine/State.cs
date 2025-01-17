using UnityEngine;

public abstract class State : MonoBehaviour
{
    protected StateMachineBase stateMachine;
    public void SetContext(StateMachineBase stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    public abstract void Enter();  
    public abstract void HandleInput();
    public abstract void LogicUpdate();
    public abstract void Exit(); 
}
