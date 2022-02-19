using UnityEngine;

namespace Hero
{
    [System.Serializable]
    public class HeroData
    {
        public int level;
        public int health;
        public Vector3 position;

        public HeroData(HeroController hero)
        {
            level = hero.level;
            // health = hero.health;
        
            position = hero.transform.position;

        }
    }
}
