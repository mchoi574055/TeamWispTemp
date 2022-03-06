using UnityEngine;

namespace Hero.StateMachine
{
    public class Encircle : StateMachineBehaviour
    {
        private HeroController heroController;
        
        private const string SlashState = "Slash";
        
        private Behaviours.Encircle encircle;
        
        private float chargeCooldownTime;
        
        private static readonly int velocityX = Animator.StringToHash("VelocityX");
        private static readonly int velocityY = Animator.StringToHash("VelocityY");
        
        // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            heroController = animator.GetComponent<HeroController>();

            chargeCooldownTime = heroController.GetTimePerAttack();
            
            encircle = animator.GetComponent<Behaviours.Encircle>();
            encircle.enabled = true;
        }

        // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (heroController.GetMainTarget() == null)
            {
                animator.Play("Follow Path");
                return;
            }
            
            animator.SetFloat(velocityX, encircle.GetDirection().x);
            animator.SetFloat(velocityY, encircle.GetDirection().y);
            
            chargeCooldownTime -= Time.deltaTime;
            if(chargeCooldownTime <= 0)
            {
                animator.Play(SlashState);
                chargeCooldownTime = heroController.GetTimePerAttack();
            }
        }

        // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            encircle.enabled = false;
        }
    }
}
