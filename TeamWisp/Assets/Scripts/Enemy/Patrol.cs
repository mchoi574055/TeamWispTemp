using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : StateMachineBehaviour
{
    // patrol path
    private Transform[] path;

    // current goal and index
    public int currentPoint;
    public Transform currentGoal;

    // margin: distance from goal before changing to next goal
    // chaseRadius: trigger radius for chase
    public float margin = 0.2f;
    public float chaseRadius = 5.0f;
    public float speed;
    private GameObject player;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        path = animator.GetComponent<EnemyController>().getPaths();
        currentGoal = path[0];
        currentPoint = 0;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (player == null)
            return;
        float dist = Vector3.Distance(animator.transform.position, player.transform.position);
        
        // player enters radius, so chase
        if (dist <= chaseRadius)
        {
            animator.SetTrigger("Chase");
        }
        // patrol goal reached; change goals
        if (Vector3.Distance(animator.transform.position, currentGoal.position) <= margin)
        {
            changeGoal();
        }
        // move to goal
        else
        {
            Vector3 temp = Vector3.MoveTowards(animator.transform.position,
                                                currentGoal.position,
                                                speed * Time.deltaTime);

            animator.transform.position = temp;
        }
    }

    // move on to next goal
    private void changeGoal()
    {
        if (currentPoint == path.Length - 1)
        {
            currentPoint = 0;
            currentGoal = path[0];
        }
        else
        {
            currentPoint++;
            currentGoal = path[currentPoint];
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Chase");
    }
}
