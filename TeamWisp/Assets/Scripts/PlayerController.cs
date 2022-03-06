using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    public UnityEvent abilityOneUsed; 
    
    // Start is called before the first frame update
    void Start()
    {
        if (abilityOneUsed == null) abilityOneUsed = new UnityEvent();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    void OnAbilityOne()
    {
        Debug.Log("test");
        abilityOneUsed.Invoke();
    }
}
