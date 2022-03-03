using System;
using System.Collections;
using System.Collections.Generic;
using Hero;
using UnityEngine;

public class CombatSaveManager : MonoBehaviour
{
    private SaveData saveData;

    [SerializeField] private HeroController hero;

    // Start is called before the first frame update
    private void Awake()
    {
        
    }

    void Start()
    {
        if (SaveSystem.Load() == null)
        {
            saveData = new SaveData();
        }
        else
        {
            saveData = SaveSystem.Load();
        }

        hero.LoadHero(saveData.heroData);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    //Events

    public void OnTestKey1()
    {
        Save();
    }
    
    // Methods
    void Save()
    {
        saveData.heroData = hero.GetHeroData();
        
        SaveSystem.Save(0, saveData);
    }    
    
}
