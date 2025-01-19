
using UnityEngine;

public class EFWBehavior : MonoBehaviour
{
    private Rigidbody2D rb;
    private EFWStateMachine stateMachine;
    
    public bool isAttacking;
    public bool isMoving;
    
    [SerializeField] private Collider2D physicCollider;
    [SerializeField] private Collider2D attackCollider;
    [SerializeField] private Collider2D attackZoneCollider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        stateMachine = GetComponent<EFWStateMachine>();
        
        isAttacking = false;
        isMoving = false;
        
        stateMachine.ChangeState(stateMachine.idle);
    }

    // Update is called once per frame
    private void Update()
    {
        stateMachine.StateUpdate();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        IDamageable target = other.GetComponent<IDamageable>();

        if (target != null && other.CompareTag("Player"))
        {
            if (other.IsTouching(attackCollider))
            {
                isAttacking = true;
                isMoving = false;
                
            } 
            else if (other.IsTouching(attackZoneCollider))
            {
                isAttacking = false;
                isMoving = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        isAttacking = false;
        isMoving = false;
    }
}
