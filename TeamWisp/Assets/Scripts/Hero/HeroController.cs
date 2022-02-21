using UnityEngine;

namespace Hero
{
    
    public class HeroController : MonoBehaviour
    {
        private EnemyBasic enemyBasic;
        public void Start()
        {
            enemyBasic = gameObject.AddComponent<EnemyBasic>();
            enemyBasic.init();
            enemyBasic.enabled = false;
        }
        
        public int level = 3;
        public int health = 40;

        public void OnLevelUp()
        {
            Debug.Log("P key was pressed");
            level += 1;
        }
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
