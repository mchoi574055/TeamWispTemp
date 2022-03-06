using System.Collections;
using System.Collections.Generic;
using Behaviours.Attacks;
using Hero;
using Hero.Collider;
using UnityEngine;

namespace Behaviours.Attacks
{
    public class Slash : AttackBehavior
    {
        // Fields
        private HeroAttackCollider mSlashCollider;
        private GameObject mTarget;
    
        // Member Variables
        private Vector3 mDirection = Vector3.zero;
        private float mDistance;

        private Vector3 mEndPosition;

        public void Init(float anticipationDuration, float actionDuration, float recoveryDuration, HeroAttackCollider slashCollider, GameObject target, float distance)
        {
            base.Init(anticipationDuration, actionDuration, recoveryDuration);
            mTarget = target;
            mDistance = distance;

            mSlashCollider = slashCollider;

            enabled = false;
        }

        public void UpdateTarget(GameObject target)
        {
            mTarget = target;
        }
    
        // Lifecycle
    
        protected override void OnStart()
        {
            base.OnStart();
            mEndPosition = transform.position + (mDirection.normalized * mDistance);
        }
    
        // protected override void Anticipation()
        // {
        //     base.Anticipation();
        // }
    
        protected override void OnAnticipationComplete()
        {
            base.OnAnticipationComplete();
            
            mSlashCollider.ToggleCollider(true, mDirection);
        }

        protected override void Action()
        {
            base.Action();
            transform.position = Vector3.MoveTowards(transform.position, 
                mEndPosition, 
                mDistance/mActionDuration * Time.deltaTime);
        }

        protected override void OnActionComplete()
        {
            base.OnActionComplete();
            
            mSlashCollider.ToggleCollider(false, mDirection);
        }

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

        public void SetDirection(Vector2 direction)
        {
            mDirection = direction;
        }
    }
}
