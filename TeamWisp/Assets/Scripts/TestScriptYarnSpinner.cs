using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class TestScriptYarnSpinner : MonoBehaviour
{
    [SerializeField] private InMemoryVariableStorage storage;
    
    // Start is called before the first frame update
    void Start()
    {
        bool result;
        storage.SetValue("$boo", false);
        storage.TryGetValue("$boo", out result);
        Debug.Log(result);
        storage.SetValue("$boo", true);
        storage.TryGetValue("$boo", out result);
        Debug.Log(result);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
