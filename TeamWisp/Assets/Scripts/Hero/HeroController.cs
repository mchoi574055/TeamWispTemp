using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

        private Animator animator;

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
            animator = GetComponent<Animator>();
            
            if(!targets.Contains(mainTarget)) targets.Add(mainTarget);
            
            AddBehaviours();
        }

        public void Update()
        {
            if (mainTarget == null)
            {
                targets.RemoveAll(target => target == null);
                if (targets.Count > 0)
                {
                    mainTarget = targets.First();
                    UpdateTarget();
                }
            }
        }

        // Methods

        public void DisableAllBehaviours()
        {
            followPath.enabled = false;
            chase.enabled = false;
            encircle.enabled = false;
            slash.enabled = false;
        }

        public void UpdateTarget()
        {
            chase.UpdateTarget(mainTarget);
            encircle.UpdateTarget(mainTarget);
            slash.UpdateTarget(mainTarget);
        }

        IEnumerator StopIFrames()
        {
            yield return new WaitForSeconds(invincibilityTime);
            animator.Play("Normal");
            hitbox.enabled = true;
        }
        
        public void Damage(int damage)
        {
            if (HasIFrames()) return;
            
            DisableAllBehaviours();
            slashCollider.ToggleCollider(false, Vector3.zero);
            animator.Play("Stagger");
            
            animator.Play("IFrames");
            hitbox.enabled = false;
            StartCoroutine(StopIFrames());
            
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
            return !hitbox.enabled;
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
