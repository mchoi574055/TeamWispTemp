using UnityEngine;

namespace Enemy.Ranged.StateMachine
{
    public class Patrol : StateMachineBehaviour
    {
        private RangedController rangedController;
    
        private const string ChaseState = "Chase";
    
        private Behaviours.FollowPath mFollowPath;
        private GameObject hero;
        
        private static readonly int velocityX = Animator.StringToHash("VelocityX");
        private static readonly int velocityY = Animator.StringToHash("VelocityY");

        // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            Debug.Log("Chasing!");

            rangedController = animator.GetComponent<RangedController>();
        
            hero = GameObject.FindWithTag("Hero");
        
            mFollowPath = animator.GetComponent<Behaviours.FollowPath>();
            mFollowPath.enabled = true;
        }

        // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animator.SetFloat(velocityX, mFollowPath.mDirection.x);
            animator.SetFloat(velocityY, mFollowPath.mDirection.y);
            
            float dist = Vector3.Distance(animator.transform.position, hero.transform.position);

            Debug.Log(dist);

            // player enters radius, so chase
            if (dist <= rangedController.GetChaseRadius())
            {
                animator.Play(ChaseState);
            }
        }

        // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            mFollowPath.enabled = false;
        }
    }
}
