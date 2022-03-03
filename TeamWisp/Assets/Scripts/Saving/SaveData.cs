using System.Collections;
using System.Collections.Generic;
using Hero;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public HeroData heroData = new HeroData();
    public int level = 0;
    public int checkPoint = 0;
    
    [System.Serializable]
    public class HeroData
    {
        public int health = 10;
        public int maxHealth = 10;
    }
}
