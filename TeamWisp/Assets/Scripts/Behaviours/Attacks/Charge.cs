using UnityEngine;

namespace Behaviours.Attacks
{
    public class Charge : AttackBehavior
    {
        // Fields
        private GameObject mTarget;
        
        // Member Variables
        private Vector3 mDirection;
        private float mSpeed;
        private float mDistance;

        private Vector3 mEndPosition;

        public void Init(float anticipationDuration, GameObject target, float speed, float distance)
        {
            base.Init(anticipationDuration,  speed != 0 ? distance/speed : 0);
            mTarget = target;
            mSpeed = speed;
            mDistance = distance;
            enabled = false;
        }
        
        // Lifecycle
        new void Awake()
        {
            base.Awake();
        }
        
        new void Start()
        {
            base.Start();
        }

        new void OnEnable()
        {
            base.OnEnable();
            mDirection = (mTarget.transform.position - transform.position).normalized;
            mEndPosition = transform.position + (mDirection * mDistance);
        }

        new void Update()
        {
            base.Update();
        }
        
        //Events
        protected override void OnAnticipationComplete()
        {
            
        }

        protected override void OnActionComplete()
        {
            
        }

        //Methods
        protected override void Anticipation()
        {
            
        }

        protected override void Action()
        {
            transform.position = Vector3.MoveTowards(transform.position, 
                mEndPosition, 
                mSpeed * Time.deltaTime);
        }

        protected override void Recovery()
        {
            
        }
    }
}
