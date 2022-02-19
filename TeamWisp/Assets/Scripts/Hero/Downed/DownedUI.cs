using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class DownedUI : MonoBehaviour
{
    [SerializeField] Image progressBar;
    [SerializeField] double progressDecayRate = 0.2;
    double progress;  // Progress saved as percentage. i.e. 20 means 20%, or 0.2 in the Image's fill amount 


    private void OnEnable()
    {
        progress = 0;
    }



    private void FixedUpdate()
    {
        progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, (float)progress / 100, 0.6f);
        if (progress > 0)
        {
            progress -= progressDecayRate;
        } else
        {
            progress = 0;
        }
        
    }

    public void addProgress()
    {
        progress += 10;
        if (progress > 100)
            progress = 100;
    }

}
