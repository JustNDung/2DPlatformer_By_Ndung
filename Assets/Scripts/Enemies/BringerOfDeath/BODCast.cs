using UnityEngine;
using System.Collections;

public class BODCast : State
{
    [SerializeField] private float cooldownTime = 6f;
    [SerializeField] private Collider2D castCollider;
    public override void Enter()
    {
        ((BODStateMachine)stateMachine).animator.SetBool("isCasting", true);
        StartCoroutine(castCoolDown());
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
                stateMachine.ChangeState(((BODStateMachine)stateMachine).bodWalk);
            }
    }

    private IEnumerator castCoolDown()
    {
        castCollider.enabled = false;
        yield return new WaitForSeconds(cooldownTime);
        castCollider.enabled = true;
    }

    public override void HandleInput()
    {
        
    }
}
