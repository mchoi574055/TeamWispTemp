using UnityEngine;

namespace Enemy.Ranged.StateMachine
{
    public class Chase : StateMachineBehaviour
    {
        private RangedController rangedController;
        
        private const string EncircleState = "Encircle";
        private const string PatrolState = "Patrol";
        
        private GameObject hero;
        private Behaviours.Chase mChase;
        private float attackDistance;
        
        // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            rangedController = animator.GetComponent<RangedController>();

            hero = GameObject.FindWithTag("Hero");

            attackDistance = rangedController.GetAttackRange();
            
            mChase = animator.GetComponent<Behaviours.Chase>();
            mChase.enabled = true;
        }

        // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            float dist = Vector3.Distance(animator.transform.position, hero.transform.position);
            
            if(dist <= attackDistance)
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
