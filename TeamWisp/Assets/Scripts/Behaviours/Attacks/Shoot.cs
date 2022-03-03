using UnityEngine;

namespace Behaviours.Attacks
{
    public class Shoot : AttackBehavior
    {
        // Fields
        private Projectile mProjectile;
        
        // Member Variables
        private float mStartTimePerShot;
        private float mSpeed;
        private float mRange;
        private bool mShot;
        public void Init(Projectile projectile, float startTimePerShot, float speed, float range)
        {
            base.Init(startTimePerShot, 0);
            mProjectile = projectile;
            mSpeed = speed;
            mRange = range;

            enabled = false;
        }
        
        // Lifecycle

        protected override void OnStart()
        {
            base.OnStart();
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
            Projectile proj = Instantiate(mProjectile, transform.position, Quaternion.identity);
            proj.Init(mSpeed, mRange);
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
    }
}
