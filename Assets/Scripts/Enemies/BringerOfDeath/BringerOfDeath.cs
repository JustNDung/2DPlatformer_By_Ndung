using UnityEngine;

public class BringerOfDeath : EnemyBase
{
    private BODStateMachine stateMachine;
    private BODWalk initialStateWalk;


    private void Start()
    {
        stateMachine = GetComponent<BODStateMachine>();
        initialStateWalk = GetComponent<BODWalk>();
        if (stateMachine == null)
        {
            Debug.LogError("No state machine found!");
        }
        stateMachine.ChangeState(initialStateWalk);
    }

    private void Update()
    {
        stateMachine.StateUpdate();
    }
    
    
    
}
