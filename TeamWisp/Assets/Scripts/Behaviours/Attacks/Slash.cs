using System.Collections;
using System.Collections.Generic;
using Behaviours.Attacks;
using Hero.Collider;
using UnityEngine;

namespace Behaviours.Attacks
{
    public class Slash : AttackBehavior
    {
        // Fields
        private SlashCollider mSlashCollider;
        private GameObject mTarget;
    
        // Member Variables
        private Vector3 mDirection = Vector3.zero;

        public void Init(float anticipationDuration, float actionDuration, float recoveryDuration, SlashCollider slashCollider, GameObject target)
        {
            base.Init(anticipationDuration, actionDuration, recoveryDuration);
            mTarget = target;

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
            mDirection = (mTarget.transform.position - transform.position);
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

        // protected override void Action()
        // {
        //     base.Action();
        // }

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
    }
}
