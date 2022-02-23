using Hero;
using UnityEngine;

namespace Enemy.Apple
{
    public class AppleController : MonoBehaviour
    {
        // Fields
        [SerializeField] private Transform[] path;
        
        [SerializeField] private float walkSpeed;
        
        [SerializeField] private float chaseRadius = 2f;
        [SerializeField] private float timePerCharge = 3.0f;
        
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
