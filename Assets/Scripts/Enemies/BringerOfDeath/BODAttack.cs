using System.Collections;
using UnityEngine;

public class BODAttack : State
{
    [SerializeField] private Collider2D attackCollider;
    [SerializeField] private float coolDownTime = 5f;
    
    private EntityMovement entityMovement;
    public override void Enter()
    {
        entityMovement = GetComponent<EntityMovement>();
        ((BODStateMachine)stateMachine).animator.SetBool("isAttacking", true);
    }
    
    public override void Exit()
    {
        ((BODStateMachine)stateMachine).animator.SetBool("isAttacking", false);
    }

    public override void LogicUpdate()
    {
        AnimatorStateInfo stateInfo = ((BODStateMachine)stateMachine).animator.GetCurrentAnimatorStateInfo(0);

        // Kiểm tra nếu animation "Attack" đã chạy xong
        if (stateInfo.IsName("Attack") && stateInfo.normalizedTime >= 1.0f)
        {
            StartCoroutine(attackCoolDown());
        }
    }

    private IEnumerator attackCoolDown()
    {
        attackCollider.enabled = false;
        entityMovement.enabled = true;
        stateMachine.ChangeState(((BODStateMachine)stateMachine).bodWalk);
        yield return new WaitForSeconds(coolDownTime);
        attackCollider.enabled = true;
    }

    public override void HandleInput()
    {
        
    }
    
}
