using System;
using UnityEngine;

public class BODStateMachine : StateMachineBase
{
    public Animator animator;
    public Rigidbody2D rb;

    public BODAttack bodAttack;
    public BODAttackNoEffect bodAttackNoEffect;
    public BODCast bodCast;
    public BODDeath bodDeath;
    public BODHurt bodHurt;
    public BODWalk bodWalk;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        bodAttack = GetComponent<BODAttack>();
        bodAttackNoEffect = GetComponent<BODAttackNoEffect>();
        bodCast = GetComponent<BODCast>();
        bodDeath = GetComponent<BODDeath>();
        bodHurt = GetComponent<BODHurt>();
        bodWalk = GetComponent<BODWalk>();
    }
}
