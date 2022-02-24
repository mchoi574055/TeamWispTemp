using UnityEngine;

namespace Hero
{
    public class HeroController : MonoBehaviour
    {
        [SerializeField] private Transform[] path;
        [SerializeField] private float walkSpeed;
        
        [SerializeField] private GameObject[] targets;
        [SerializeField] private float chaseRadius;
        
        [SerializeField] private float encircleRadius;
        
        // Member Variables
        private Behaviours.FollowPath followPath;
        private Behaviours.Chase chase;
        private Behaviours.Encircle encircle;
        
        // Lifecycle
        public void Start()
        {
            followPath = gameObject.AddComponent<Behaviours.FollowPath>();
            followPath.Init(path, walkSpeed);
            
            chase = gameObject.AddComponent<Behaviours.Chase>();
            chase.Init(targets[0], walkSpeed);
            
            encircle = gameObject.AddComponent<Behaviours.Encircle>();
            encircle.Init(targets[0], walkSpeed);
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
        
        public GameObject[] GetTargets()
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
