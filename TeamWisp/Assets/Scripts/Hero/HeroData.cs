using UnityEngine;

namespace Hero
{
    [System.Serializable]
    public class HeroData
    {
        public int level;
        public int health;
        public float[] position;

        public HeroData(HeroController hero)
        {
            level = hero.level;
            // health = hero.health;

            position = new float[3];
            position[0] = hero.transform.position.x;
            position[1] = hero.transform.position.y;
            position[2] = hero.transform.position.z;

        }
    }
}
