using UnityEngine;
public class Context : MonoBehaviour
{
    public State currentState;  
    public Animator animator;
    public Rigidbody2D rb;
    public Duck duck;
    public Fall fall;
    public Hurt hurt;
    public Idle idle;
    public Jump jump;
    public Ladder ladder;
    public Run run;
    public RunShoot runShoot;
    public Shoot shoot;
    public Slide slide;
    public Spin spin;
    public PlayerController playerController;

    private void Awake() {
        animator = GetComponent<Animator>();

        rb = GetComponent<Rigidbody2D>();
        duck = GetComponent<Duck>();
        fall = GetComponent<Fall>();
        hurt = GetComponent<Hurt>();
        idle = GetComponent<Idle>();
        jump = GetComponent<Jump>();
        ladder = GetComponent<Ladder>();
        run = GetComponent<Run>();
        runShoot = GetComponent<RunShoot>();
        shoot = GetComponent<Shoot>();
        slide = GetComponent<Slide>();
        spin = GetComponent<Spin>();

        playerController = GetComponent<PlayerController>();
    }
    
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
            Debug.Log("Current State: NULL");
        }
    }
}
