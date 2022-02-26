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
        public int level = 0;
        public int health = 10;
        public float[] position = {0, 0, 0};
    }
}
