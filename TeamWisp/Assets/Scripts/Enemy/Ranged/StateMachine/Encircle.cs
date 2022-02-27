using UnityEngine;

namespace Enemy.Ranged.StateMachine
{
    public class Encircle : StateMachineBehaviour
    {        
        private RangedController rangedController;
        private const string ChaseState = "Chase";
        
        private Behaviours.Encircle encircle;
        private GameObject hero;

        private static readonly int velocityX = Animator.StringToHash("VelocityX");
        private static readonly int velocityY = Animator.StringToHash("VelocityY");
        
        // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            Debug.Log("Encircling!");

            rangedController = animator.GetComponent<RangedController>();

            hero = GameObject.FindWithTag("Hero");

            encircle = animator.GetComponent<Behaviours.Encircle>();
            encircle.enabled = true;
        }

        // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animator.SetFloat(velocityX, encircle.GetDirection().x);
            animator.SetFloat(velocityY, encircle.GetDirection().y);

            float dist = Vector3.Distance(animator.transform.position, hero.transform.position);
            
            if (dist > rangedController.GetAttackDistance())
            {
                animator.Play(ChaseState);
            }
        }

        // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            Debug.Log("Exit Encircling!");
            encircle.enabled = false;
        }
    }
}