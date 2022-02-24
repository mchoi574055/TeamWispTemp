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

        protected override void OnStart()
        {
            base.OnStart();
            mDirection = (mTarget.transform.position - transform.position).normalized;
            mEndPosition = transform.position + (mDirection * mDistance);
        }
        
        // protected override void Anticipation()
        // {
        //     base.Anticipation();
        // }
        
        // protected override void OnAnticipationComplete()
        // {
        //     base.OnAnticipationComplete();
        // }

        protected override void Action()
        {
            base.Action();
            transform.position = Vector3.MoveTowards(transform.position, 
                mEndPosition, 
                mSpeed * Time.deltaTime);
        }

        // protected override void OnActionComplete()
        // {
        //     base.OnActionComplete();
        // }

        // protected override void Recovery()
        // {
        //     base.Recovery();
        // }

        // protected override void OnComplete()
        // {
        //     base.OnComplete();
        // }
    }
}
