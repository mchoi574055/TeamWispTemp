using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : StateMachineBehaviour
{
    private GameObject player;
    // chase duration before charging
    public float maxTime = 3.0f;
    private float targetTime;
    public float speed;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("Chasing!");
        targetTime = maxTime;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        targetTime -= Time.deltaTime;
        if(targetTime <= 0)
        {
            animator.SetTrigger("Charge");
        }
        animator.transform.position = Vector2.MoveTowards(animator.transform.position, player.transform.position, speed * Time.deltaTime);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("Exit Chasing!");
        animator.ResetTrigger("Charge");
        targetTime = maxTime;
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
