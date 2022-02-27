using UnityEngine;

namespace Enemy.Apple.StateMachine
{
    public class Chase : StateMachineBehaviour
    {
        private AppleController appleController;
        
        private const string ChargeState = "Charge";
        private const string PatrolState = "Patrol";
        
        private Behaviours.Chase mChase;
        
        private float chargeCooldownTime;
        
        private static readonly int velocityX = Animator.StringToHash("VelocityX");
        private static readonly int velocityY = Animator.StringToHash("VelocityY");

        // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            Debug.Log("Chasing!");
            
            appleController = animator.GetComponent<AppleController>();
            
            chargeCooldownTime = appleController.GetTimePerCharge() + Random.Range(-0.5f, 0.5f);

            mChase = animator.GetComponent<Behaviours.Chase>();
            mChase.enabled = true;
        }

        // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animator.SetFloat(velocityX, mChase.GetDirection().x);
            animator.SetFloat(velocityY, mChase.GetDirection().y);
            
            chargeCooldownTime -= Time.deltaTime;
            if(chargeCooldownTime <= 0)
            {
                animator.Play(ChargeState);
            }
        }

        // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            Debug.Log("Exit Chasing!");
            mChase.enabled = false;
        }
    }
}
