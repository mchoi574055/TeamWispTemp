using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueBubble : MonoBehaviour
{
    [SerializeField] private Vector3 Offset;
    [SerializeField] private GameObject dialogueBox;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        dialogueBox.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + Offset);
    }
}
