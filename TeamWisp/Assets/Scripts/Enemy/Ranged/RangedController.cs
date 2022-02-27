using Hero;
using UnityEngine;

namespace Enemy.Ranged
{
    public class RangedController : MonoBehaviour
    {
        // Fields
        [SerializeField] private Transform[] path;
        
        [SerializeField] private float walkSpeed;
        
        [SerializeField] private float chaseRadius = 5f;
        [SerializeField] private float attackDistance = 3f;
        
        // Member Variables
        private GameObject hero;
        private HeroController heroController;
        private Behaviours.FollowPath mFollowPath;
        private Behaviours.Chase mChase;
        private Behaviours.Encircle encircle;
    
        // Lifecycle
        void Start()
        {
            hero = GameObject.FindGameObjectWithTag("Hero");
            heroController = hero.GetComponent<HeroController>();
        
            mFollowPath = gameObject.AddComponent<Behaviours.FollowPath>();
            mFollowPath.Init(path, walkSpeed);
        
            mChase = gameObject.AddComponent<Behaviours.Chase>();
            mChase.Init(hero, walkSpeed);

            encircle = gameObject.AddComponent<Behaviours.Encircle>();
            encircle.Init(hero, walkSpeed);
        }

        void Update()
        {
        
        }
        
        // Getters and Setters
        public float GetChaseRadius()
        {
            return chaseRadius;
        }

        public float GetAttackDistance()
        {
            return attackDistance;
        }
    }
}
