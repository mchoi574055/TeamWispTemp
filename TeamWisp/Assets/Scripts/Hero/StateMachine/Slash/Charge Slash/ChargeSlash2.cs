using UnityEngine;

namespace Hero.StateMachine.Slash.Charge_Slash
{
    public class ChargeSlash2 : StateMachineBehaviour
    {
        private HeroController heroController;
        
        private const string Anticipation = "Charge Slash2 Anticipation";
        private const string Action = "Charge Slash2 Action";
        private const string Recovery = "Charge Slash2 Recovery";

        private const string Encircle = "Encircle";

        private Behaviours.Attacks.Slash mSlash;
        
        private static readonly int velocityX = Animator.StringToHash("VelocityX");
        private static readonly int velocityY = Animator.StringToHash("VelocityY");

        // OnStateMachineEnter is called when entering a state machine via its Entry Node
        public override void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
        {
            heroController = animator.GetComponent<HeroController>();
            heroController.hitbox.enabled = false;
            
            mSlash = heroController.superSlash;
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
                }
                else
                {
                    animator.Play(Encircle);
                }
                heroController.hitbox.enabled = true;
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
