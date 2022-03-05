using System;
using System.Collections;
using System.Collections.Generic;
using Hero.Collider;
using UnityEngine;


namespace Hero
{
    
    
    public class HeroController : MonoBehaviour
    {
        // Hero Data
        [SerializeField] private SaveData.HeroData heroData;
        
        // Path
        [SerializeField] private Transform[] path;
        [SerializeField] private float walkSpeed;
        
        // Combat
        [SerializeField] private Collider2D hitbox;
        [SerializeField] private float timePerAttack;
        [SerializeField] private SlashCollider slashCollider;
        [SerializeField] private float invincibilityTime;
        
        [SerializeField] private GameObject mainTarget;
        [SerializeField] private List<GameObject> targets;
        [SerializeField] private float chaseRadius;
        
        [SerializeField] private float encircleRadius;
        
        // Member Variables
        private Behaviours.FollowPath followPath;
        private Behaviours.Chase chase;
        private Behaviours.Encircle encircle;
        private Behaviours.Attacks.Slash slash;

        void AddBehaviours()
        {
            followPath = gameObject.AddComponent<Behaviours.FollowPath>();
            followPath.Init(path, walkSpeed);
            
            chase = gameObject.AddComponent<Behaviours.Chase>();
            chase.Init(mainTarget, walkSpeed);
            
            encircle = gameObject.AddComponent<Behaviours.Encircle>();
            encircle.Init(mainTarget, walkSpeed, encircleRadius);

            slash = gameObject.AddComponent<Behaviours.Attacks.Slash>();
            slash.Init(0.1f, 0.25f, 0.1f, slashCollider, mainTarget);
        }
        
        // Lifecycle
        public void Start()
        {
            if(!targets.Contains(mainTarget)) targets.Add(mainTarget);
            
            AddBehaviours();
        }
        
        // Events

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Enemy") && !HasIFrames())
            {
                GetComponent<Animator>().Play("IFrames");
                hitbox.enabled = false;
                StartCoroutine(StopIFrames());
            }
        }

        // Methods

        IEnumerator StopIFrames()
        {
            yield return new WaitForSeconds(invincibilityTime);
            GetComponent<Animator>().Play("Normal");
            hitbox.enabled = true;
        }
        
        public void Damage(int damage)
        {
            if (HasIFrames()) return;
            
            heroData.health -= damage;

            if(heroData.health > heroData.maxHealth){
                heroData.health = heroData.maxHealth;
            } else if (heroData.health <= 0){
                heroData.health = 0;
            }
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
        
        // Getter and Setter
        public bool HasIFrames()
        {
            return GetComponent<Animator>().GetCurrentAnimatorStateInfo(1).IsName("IFrames");
        }
        
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

        public float GetTimePerAttack()
        {
            return timePerAttack;
        }
    }
}
