using UnityEngine;

public abstract class StateMachineBase : MonoBehaviour
{
    protected State currentState;
    
    public void ChangeState(State newState)
    {
        if (currentState != null)
        {
            currentState.Exit();  
        }

        this.currentState = newState;
        this.currentState.SetContext(this);  
        this.currentState.Enter();  

    }
    public void StateUpdate()
    {
        if (this.currentState != null)
        {
            this.currentState.HandleInput();  
            this.currentState.LogicUpdate();       
        } 
        else
        {
            throw new System.Exception("Current State is null");
        }
    }
}
