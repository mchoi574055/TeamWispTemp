using UnityEngine;

namespace Enemy.Ranged.StateMachine
{
    public class Shoot : StateMachineBehaviour
    {
        private RangedController rangedController;
        
        private const string Anticipation = "Shoot Anticipation";
        private const string Action = "Shoot Action";
        private const string Recovery = "Shoot Recovery";

        private const string StopState = "Ready";

        private Behaviours.Attacks.Shoot mShoot;

        // OnStateMachineEnter is called when entering a state machine via its Entry Node
        public override void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
        {
            rangedController = animator.GetComponent<RangedController>();
            
            mShoot = animator.GetComponent<Behaviours.Attacks.Shoot>();
            mShoot.enabled = true;
            mShoot.anticipationComplete.AddListener(() =>
            {
                animator.Play(Action);
            });
            mShoot.actionComplete.AddListener(() =>
            {
                animator.Play(Recovery);
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
            animator.Play(StopState);
            mShoot.enabled = false;
        }
    }
}
