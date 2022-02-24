using Behaviours;
using UnityEngine;

namespace Hero.StateMachine
{
    public class Chase : StateMachineBehaviour
    {
        private HeroController heroController;
        
        private const string FollowPathState = "Follow Path";
        private const string EncircleState = "Encircle";
        
        private Behaviours.Chase mChase;
        
        private static readonly int velocityX = Animator.StringToHash("VelocityX");
        private static readonly int velocityY = Animator.StringToHash("VelocityY");
    
        // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            heroController = animator.GetComponent<HeroController>();
            
            mChase = animator.GetComponent<Behaviours.Chase>();
            mChase.enabled = true;
        }

        // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animator.SetFloat(velocityX, mChase.GetDirection().x);
            animator.SetFloat(velocityY, mChase.GetDirection().y);
            
            float dist = Vector3.Distance(animator.transform.position, heroController.GetTargets()[0].transform.position);
            if (dist > heroController.GetChaseRadius())
            {
                animator.Play(FollowPathState);
            }else if (dist < heroController.GetEncircleRadius())
            {
                animator.Play(EncircleState);
            }
        }

        // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            mChase.enabled = false;
        }
    }
}
