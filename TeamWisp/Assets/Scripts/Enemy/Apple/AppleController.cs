using System;
using Hero;
using UnityEngine;

namespace Enemy.Apple
{
    public class AppleController : MonoBehaviour
    {
        // Fields
        [SerializeField] private Transform[] path;
        
        [Space]
        [SerializeField] private float walkSpeed;

        [Space] 
        [SerializeField] private int contactDamage;
        [SerializeField] private int chargeDamage;
        
        [Space]
        [SerializeField] private float chaseRadius = 2f;
        [SerializeField] private float timePerCharge = 3.0f;
        
        [Space]
        [SerializeField] private float chargeSpeed;
        [SerializeField] private float chargeDistance;
        [SerializeField] private float chargeAnticipationTime;
        // Member Variables
        private Behaviours.FollowPath mFollowPath;
        private Behaviours.Chase mChase;
        private Behaviours.Attacks.Charge mCharge;

        private GameObject hero;
        private HeroController heroController;
    
        // Lifecycle
        void Start()
        {
            hero = GameObject.FindGameObjectWithTag("Hero");
            heroController = hero.GetComponent<HeroController>();
        
            mFollowPath = gameObject.AddComponent<Behaviours.FollowPath>();
            mFollowPath.Init(path, walkSpeed);
        
            mChase = gameObject.AddComponent<Behaviours.Chase>();
            mChase.Init(hero, walkSpeed);

            mCharge = gameObject.AddComponent<Behaviours.Attacks.Charge>();
            mCharge.Init(chargeAnticipationTime, 
                hero, chargeSpeed, chargeDistance);
        }

        void Update()
        {
        
        }
        
        // Events

        private void OnTriggerEnter2D(Collider2D col)
        {
            Debug.Log(col.tag);
            if (col.CompareTag("Hero"))
            {
                if (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Charge Action"))
                {
                    heroController.UpdateHealth(-chargeDamage);
                }
                else
                {
                    heroController.UpdateHealth(-contactDamage);
                }
            }
        }

        // Getters and Setters
        public float GetChaseRadius()
        {
            return chaseRadius;
        }

        public float GetTimePerCharge()
        {
            return timePerCharge;
        }
    }
}
