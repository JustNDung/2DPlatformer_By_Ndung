using System;
using UnityEngine;

public class EFWStateMachine : StateMachineBase
{
    public Animator anim;
    
    public EFWHurt hurt;
    public EFWDead dead;
    public EFWIdle idle;
    public EFWAttack attack;
    public EFWMove move;

    private void Awake()
    {
        anim = GetComponent<Animator>();

        hurt = GetComponent<EFWHurt>();
        dead = GetComponent<EFWDead>();
        idle = GetComponent<EFWIdle>();
        attack = GetComponent<EFWAttack>();
        move = GetComponent<EFWMove>();
        
    }
}
