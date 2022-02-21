using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : StateMachineBehaviour
{
    private Hero.Movement.FollowPath followPath;
    private static readonly int velocityX = Animator.StringToHash("VelocityX");
    private static readonly int velocityY = Animator.StringToHash("VelocityY");

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        followPath = animator.GetComponent<Hero.Movement.FollowPath>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetFloat(velocityX, followPath.direction.x);
        animator.SetFloat(velocityY, followPath.direction.y);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}
