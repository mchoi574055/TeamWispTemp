using UnityEngine;

namespace Hero.StateMachine.Slash
{
    public class Slash1 : StateMachineBehaviour
    {
        private HeroController heroController;
        
        private const string Anticipation = "Slash1 Anticipation";
        private const string Action = "Slash1 Action";
        private const string Recovery = "Slash1 Recovery";

        private const string Slash2 = "Slash2";

        private Behaviours.Attacks.Slash mSlash;
        
        private static readonly int velocityX = Animator.StringToHash("VelocityX");
        private static readonly int velocityY = Animator.StringToHash("VelocityY");

        // OnStateMachineEnter is called when entering a state machine via its Entry Node
        public override void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
        {
            heroController = animator.GetComponent<HeroController>();
            
            mSlash = heroController.slash;
            mSlash.SetDirection(new Vector2(animator.GetFloat(velocityX), animator.GetFloat(velocityY)));
            mSlash.enabled = true;
            mSlash.anticipationComplete.AddListener(() =>
            {
                animator.Play(Action);
            });
            mSlash.actionComplete.AddListener(() =>
            {
                animator.Play(Recovery);
            });
            mSlash.recoveryComplete.AddListener(() =>
            {
                if (heroController.GetMainTarget() == null)
                {
                    animator.Play("Follow Path");
                    mSlash.enabled = false;
                    return;
                }
                animator.Play(Slash2);
                mSlash.enabled = false;
            });
        }

        // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            
        }

        // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            
        }

        // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            
        }

        // OnStateMachineExit is called when exiting a state machine via its Exit Node
        public override void OnStateMachineExit(Animator animator, int stateMachinePathHash)
        {
            
        }
    }
}
