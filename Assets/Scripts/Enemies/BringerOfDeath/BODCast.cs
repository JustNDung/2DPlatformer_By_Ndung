using UnityEngine;
using System.Collections;

public class BODCast : State
{
    [SerializeField] private float cooldownTime = 6f;
    [SerializeField] private Collider2D castCollider;
    // [SerializeField] private SpellCollider spellCollider;
    private EntityMovement entityMovement;
    public override void Enter()
    {
        entityMovement = GetComponent<EntityMovement>();
        ((BODStateMachine)stateMachine).animator.SetBool("isCasting", true);
    }
    
    public override void Exit()
    {
        ((BODStateMachine)stateMachine).animator.SetBool("isCasting", false);
    }

    public override void LogicUpdate()
    {
            AnimatorStateInfo spellInfo = ((BODStateMachine)stateMachine).animator.GetCurrentAnimatorStateInfo(0);
            // Kiểm tra nếu animation "Attack" đã chạy xong
            if (spellInfo.IsName("Cast") && spellInfo.normalizedTime >= 1.0f)
            {
                StartCoroutine(attackCoolDown());
            }
    }

    private IEnumerator attackCoolDown()
    {
        castCollider.enabled = false;
        entityMovement.enabled = true;
        stateMachine.ChangeState(((BODStateMachine)stateMachine).bodWalk);
        yield return new WaitForSeconds(cooldownTime);
        castCollider.enabled = true;
    }

    public override void HandleInput()
    {
        
    }
}
