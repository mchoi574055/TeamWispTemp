using UnityEngine;

namespace Behaviours.Attacks
{
    public class Charge : AttackBehavior
    {
        // Fields
        private GameObject mTarget;
        
        // Member Variables
        private Vector3 mDirection = Vector3.zero;
        private float mSpeed;
        private float mDistance;

        private Vector3 mEndPosition;

        public void Init(float anticipationDuration, float recoveryDuration, GameObject target, float speed, float distance)
        {
            base.Init(anticipationDuration,  speed != 0 ? distance/speed : 0, recoveryDuration);
            mTarget = target;
            mSpeed = speed;
            mDistance = distance;
            
            enabled = false;
        }
        
        // Lifecycle

        protected override void OnStart()
        {
            base.OnStart();
            mDirection = (mTarget.transform.position - transform.position);
            mEndPosition = transform.position + (mDirection.normalized * mDistance);
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
        
        // Getters and Setters
        public Vector3 GetDirection()
        {
            return mDirection.magnitude > 0.1 ? mDirection.normalized : Vector3.zero;
        }
    }
}
