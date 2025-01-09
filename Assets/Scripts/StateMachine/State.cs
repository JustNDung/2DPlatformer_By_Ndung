using UnityEngine;

public abstract class State : MonoBehaviour
{
    protected Context context;
    public void SetContext(Context context)
    {
        this.context = context;
    }

    public abstract void Enter();  
    public abstract void HandleInput();
    public abstract void LogicUpdate();
    public abstract void Exit(); 
}
