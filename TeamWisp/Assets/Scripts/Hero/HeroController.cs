using System.Collections.Generic;
using UnityEngine;

namespace Hero
{
    public class HeroController : MonoBehaviour
    {
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
        
        public int level = 3;
        public int health = 40;

        // Methods
        public void OnLevelUp()
        {
            Debug.Log("P key was pressed");
            level += 1;
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
        public void OnSave()
        {
            Debug.Log("s key pressed");
            SaveHero();
        
        }

        public void OnLoad()
        {
            Debug.Log("l key pressed");
            LoadHero();

        }
        public void SaveHero()
        {
            SaveSystem.SaveHero(this);
        }

        public void LoadHero()
        {
            HeroData data = SaveSystem.LoadHero();

            level = data.level;
            // health = data.health

            Vector3 position;
            position.x = data.position[0];
            position.y = data.position[1];
            position.z = data.position[2];
            transform.position = position;
        }
    }
}
