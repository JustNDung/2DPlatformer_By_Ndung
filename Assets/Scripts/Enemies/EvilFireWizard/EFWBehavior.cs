using UnityEngine;

public class EFWBehavior : MonoBehaviour
{
    private Rigidbody2D rb;
    private EFWStateMachine stateMachine;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        stateMachine = GetComponent<EFWStateMachine>();
        
        stateMachine.ChangeState(stateMachine.idle);
    }

    // Update is called once per frame
    void Update()
    {
        stateMachine.StateUpdate();
    }
}
