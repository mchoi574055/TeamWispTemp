using Hero;
using UnityEngine;

namespace Enemy.Ranged
{
    public class RangedController : MonoBehaviour
    {
        // Fields
        [SerializeField] private Transform[] path;
        
        [SerializeField] private float walkSpeed;
        
        [SerializeField] private float chaseRadius = 2f;
        
        // Member Variables
        private Behaviours.FollowPath mFollowPath;
        private Behaviours.Chase mChase;
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
        }

        void Update()
        {
        
        }
        
        // Getters and Setters
        public float GetChaseRadius()
        {
            return chaseRadius;
        }
    }
}
