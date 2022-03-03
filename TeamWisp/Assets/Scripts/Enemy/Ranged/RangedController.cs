using Hero;
using UnityEngine;

namespace Enemy.Ranged
{
    public class RangedController : MonoBehaviour
    {
        // Fields
        public Behaviours.Attacks.Projectile projectile;
        [SerializeField] private Transform[] path;
        [SerializeField] private float walkSpeed;
        [SerializeField] private float chaseRadius = 5f;
        [SerializeField] private float startTimePerShot = 2f;
        [SerializeField] private float shootSpeed;
        [SerializeField] private float shootRange;        
        // Member Variables
        private GameObject hero;
        private HeroController heroController;
        private Behaviours.FollowPath mFollowPath;
        private Behaviours.Chase mChase;
        private Behaviours.Encircle mEncircle;
        private Behaviours.Attacks.Shoot mShoot;
    
        // Lifecycle
        void Start()
        {
            hero = GameObject.FindGameObjectWithTag("Hero");
            heroController = hero.GetComponent<HeroController>();
        
            mFollowPath = gameObject.AddComponent<Behaviours.FollowPath>();
            mFollowPath.Init(path, walkSpeed);
        
            mChase = gameObject.AddComponent<Behaviours.Chase>();
            mChase.Init(hero, walkSpeed);

            mEncircle = gameObject.AddComponent<Behaviours.Encircle>();
            mEncircle.Init(hero, walkSpeed);

            mShoot = gameObject.AddComponent<Behaviours.Attacks.Shoot>();
            mShoot.Init(projectile, startTimePerShot, shootSpeed, shootRange);


        }

        void Update()
        {
        
        }
        
        // Getters and Setters
        public float GetChaseRadius()
        {
            return chaseRadius;
        }

        public float GetAttackRange()
        {
            return shootRange;
        }
    }
}
