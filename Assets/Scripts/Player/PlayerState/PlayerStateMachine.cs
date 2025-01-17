using UnityEngine;
public class PlayerStateMachine : StateMachineBase
{
    public Animator animator;
    public Rigidbody2D rb;
    
    public PlayerController playerController;
    
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
    
    private void Awake() {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        
        playerController = GetComponent<PlayerController>();

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
        
    }
}
