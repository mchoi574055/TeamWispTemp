using System.Collections;
using System.Collections.Generic;
using Menus;
using UnityEngine;

public class TitleScreenManager : MonoBehaviour
{
    public bool canStart = false;
    
    [SerializeField] private GameObject spear;
    private SpearBillboard spearBillboard;
    
    [SerializeField] private Camera mCamera;
    private CameraDrift cameraDrift;
    
    // Lifecycle
    void Start()
    {
        spearBillboard = spear.GetComponent<SpearBillboard>();
        cameraDrift = mCamera.GetComponent<CameraDrift>();
        
        GetComponent<Animator>().Play("Intro");
    }

    
    void Update()
    {
        
    }
    
    // Methods
    void CanStartNow()
    {
        canStart = true;
    }
    
    void StartDrift()
    {
        cameraDrift.SetDrift(true);
    }

    void StopDrift()
    {
        cameraDrift.SetDrift(false);
    }
}
