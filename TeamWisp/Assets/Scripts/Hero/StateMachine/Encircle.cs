using UnityEngine;

namespace Hero.StateMachine
{
    public class Encircle : StateMachineBehaviour
    {
        private HeroController heroController;
        
        private const string ChaseState = "Chase";
        
        private Behaviours.Encircle encircle;
        
        private static readonly int velocityX = Animator.StringToHash("VelocityX");
        private static readonly int velocityY = Animator.StringToHash("VelocityY");
        
        // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            heroController = animator.GetComponent<HeroController>();
            
            encircle = animator.GetComponent<Behaviours.Encircle>();
            encircle.enabled = true;
        }

        // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animator.SetFloat(velocityX, encircle.GetDirection().x);
            animator.SetFloat(velocityY, encircle.GetDirection().y);
            
            float dist = Vector3.Distance(animator.transform.position, heroController.GetMainTarget().transform.position);
            if (dist > heroController.GetEncircleRadius())
            {
                animator.Play(ChaseState);
            }
        }

        // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            encircle.enabled = false;
        }
    }
}
