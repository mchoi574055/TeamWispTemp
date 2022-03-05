using UnityEngine;

namespace Enemy.Apple.StateMachine
{
    public class Charge : StateMachineBehaviour
    {
        private AppleController appleController;
        
        private const string Anticipation = "Charge Anticipation";
        private const string Action = "Charge Action";
        private const string Recovery = "Charge Recovery";

        private const string ChaseState = "Chase";

        private Behaviours.Attacks.Charge mCharge;

        // OnStateMachineEnter is called when entering a state machine via its Entry Node
        public override void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
        {
            appleController = animator.GetComponent<AppleController>();
            
            mCharge = animator.GetComponent<Behaviours.Attacks.Charge>();
            mCharge.enabled = true;
            mCharge.anticipationComplete.AddListener(() =>
            {
                animator.Play(Action);
            });
            mCharge.actionComplete.AddListener(() =>
            {
                animator.Play(Recovery);
            });
            mCharge.recoveryComplete.AddListener(() =>
            {
                animator.Play(ChaseState);
                mCharge.enabled = false;
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
    }
}
