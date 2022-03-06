using UnityEngine;

namespace Hero.StateMachine.Slash
{
    public class BeginSlashCombo : StateMachineBehaviour
    {
        private PlayerController playerController;

        private const string ChargedSlash = "Charge Slash1";

        private Behaviours.Attacks.Slash mSlash;
    
        // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        
            mSlash = animator.GetComponent<Behaviours.Attacks.Slash>();
        
            playerController.abilityOneUsed.AddListener(() =>
            {
                float tempTime = stateInfo.normalizedTime;
                animator.Play(ChargedSlash, 0, tempTime);
                mSlash.enabled = false;
            });
        }

        // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
        // override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        // {
        //     
        // }

        // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            // TODO Fix this, should only remove above listener
            playerController.abilityOneUsed.RemoveAllListeners();
        }
    }
}
