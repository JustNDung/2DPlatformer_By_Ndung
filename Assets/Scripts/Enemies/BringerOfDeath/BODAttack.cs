using System.Collections;
using UnityEngine;

public class BODAttack : State
{
    [SerializeField] private GameObject attackHitBox;
    [SerializeField] private float coolDownTime = 5f;
    
    private EntityMovement entityMovement;
    public override void Enter()
    {
        entityMovement = GetComponent<EntityMovement>();
        ((BODStateMachine)stateMachine).animator.SetBool("isAttacking", true);
        StartCoroutine(attackCoolDown());
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
            stateMachine.ChangeState(((BODStateMachine)stateMachine).bodWalk);
        }
    }

    private IEnumerator attackCoolDown()
    {
        AttackCollider attackCollider = attackHitBox.GetComponent<AttackCollider>();
        if (attackCollider)
        {
            attackCollider.enabled = false;
            Debug.Log(attackCollider.target);
        }
        yield return new WaitForSeconds(coolDownTime);
        if (attackCollider)
        {
            attackCollider.enabled = true;
        }
    }
    public override void HandleInput()
    {
        
    }
    
}
