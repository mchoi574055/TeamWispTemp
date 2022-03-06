using UnityEngine;

namespace Enemy.Apple.StateMachine
{
    public class BackOff : StateMachineBehaviour
    {
        private AppleController appleController;
        
        private Behaviours.BackOff mBackOff;
    
        private const string PatrolState = "Patrol";
        
        private static readonly int velocityX = Animator.StringToHash("VelocityX");
        private static readonly int velocityY = Animator.StringToHash("VelocityY");
    
        // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            appleController = animator.GetComponent<AppleController>();

            mBackOff = animator.GetComponent<Behaviours.BackOff>();
            mBackOff.enabled = true;
        }

        // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animator.SetFloat(velocityX, mBackOff.GetDirection().x);
            animator.SetFloat(velocityY, mBackOff.GetDirection().y);

            if (mBackOff.Complete())
            {
                animator.Play(PatrolState);
            }
        }

        // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            mBackOff.enabled = false;
        }
    }
}
