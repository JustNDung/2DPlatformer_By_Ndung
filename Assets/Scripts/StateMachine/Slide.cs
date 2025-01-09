using UnityEngine;

public class Slide : State
{
    private float slideStartTime;
    private float slideDuration = 2.0f; // Thời gian trượt (tuỳ chỉnh logic)
    public override void Enter()
    {
        StartSlide(); 
        context.animator.SetBool("isSliding", true);    

        slideStartTime = Time.time;
    }

    public override void HandleInput()
    {
        if (!Input.GetKey(KeyCode.LeftControl)) // Khi thả phím cúi
        {
            context.ChangeState(context.idle);
        }
    }

    public override void LogicUpdate()
    {
         
    }

    public override void Exit()
    {
        StopSlide(); 
    }

    private void StartSlide()
    {

    }

    private void StopSlide()
    {
        context.animator.SetBool("isSliding", false);
    }

    private bool HasFinishedSliding()
    {
        return Time.time > slideStartTime + slideDuration; // Dừng sau 2 giây (tuỳ chỉnh logic)
    }
}
