using System.Collections.Generic;
using UnityEngine;


namespace Hero
{
    
    
    public class HeroController : MonoBehaviour
    {
        [SerializeField] private SaveData.HeroData heroData;
        
        [SerializeField] private Transform[] path;
        [SerializeField] private float walkSpeed;
        [SerializeField] private GameObject mainTarget;
        [SerializeField] private List<GameObject> targets;
        [SerializeField] private float chaseRadius;
        
        [SerializeField] private float encircleRadius;
        
        // Member Variables
        private Behaviours.FollowPath followPath;
        private Behaviours.Chase chase;
        private Behaviours.Encircle encircle;

        void AddBehaviours()
        {
            followPath = gameObject.AddComponent<Behaviours.FollowPath>();
            followPath.Init(path, walkSpeed);
            
            chase = gameObject.AddComponent<Behaviours.Chase>();
            chase.Init(mainTarget, walkSpeed);
            
            encircle = gameObject.AddComponent<Behaviours.Encircle>();
            encircle.Init(mainTarget, walkSpeed);
        }
        
        // Lifecycle
        public void Start()
        {
            if(!targets.Contains(mainTarget)) targets.Add(mainTarget);
            
            AddBehaviours();
        }

        // Methods
        
        public void UpdateHealth(int mod){
            heroData.health += mod;

            if(heroData.health > heroData.maxHealth){
                heroData.health = heroData.maxHealth;
            } else if (heroData.health <= 0){
                heroData.health = 0;
                Debug.Log("Hero Dead");
            }
        }
        
        // Getter and Setter
        public float GetChaseRadius()
        {
            return chaseRadius;
        }

        public float GetEncircleRadius()
        {
            return encircleRadius;
        }

        public GameObject GetMainTarget()
        {
            return mainTarget;
        }
        
        public List<GameObject> GetTargets()
        {
            return targets;
        }

        // Saving
        public SaveData.HeroData GetHeroData()
        {
            return heroData;
        }

        public void LoadHero(SaveData.HeroData heroData)
        {
            this.heroData = heroData;
        }
    }
}
