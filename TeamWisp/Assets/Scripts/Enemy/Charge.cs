using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charge : StateMachineBehaviour
{
    // charge speed of enemy
    public float chargeSpeed;

    // maxChargeupTime: time to stop before charging
    // maxChargeTime: duration of acutal charge
    public float maxChargeupTime = 1.0f;
    public float maxChargeTime = 1.0f;
    private float currentchargeupTimer;
    private float currentChargeTime = 1.0f;

    private GameObject player;
    private Rigidbody2D rb;
    private Vector3 chargeDir;
   
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("Charging!");
        rb = animator.GetComponent<Rigidbody2D>();
        rb.velocity = Vector3.zero;
        currentchargeupTimer = maxChargeupTime;
        currentChargeTime = maxChargeTime;
        player = GameObject.FindGameObjectWithTag("Player");
        chargeDir = player.transform.position - animator.transform.position;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // decrement chargeup timer
        if(currentchargeupTimer > 0)
        {
            currentchargeupTimer -= Time.deltaTime;
            
        }
        // charge fr
        else
        {
            if(currentChargeTime <= 0)
            {
                animator.SetTrigger("Chase");

            }
            else
            {
                currentChargeTime -= Time.deltaTime;
                rb.velocity = chargeDir.normalized * chargeSpeed;
            }
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("Exit Charging!");
        animator.ResetTrigger("Chase");
        rb.velocity = Vector3.zero;
        currentchargeupTimer = maxChargeupTime;
        currentChargeTime = maxChargeTime;
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
