using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ToggleAbility : MonoBehaviour
{
    [SerializeField] Text TextAbilityType;

    string[] Abilities = {"ability1", "ability2", "ability3"};
    private int counter = 0;
    private string currentAbility = "No Ability";

    // Start is called before the first frame update
    void Start()
    {
        DisplayAbility();
    }

    public void SwitchAbility() {
        counter++;
        if (counter == 3) counter = 0;
        currentAbility = Abilities[counter];
        DisplayAbility();
    }

    void DisplayAbility() {
        TextAbilityType.text = currentAbility;
    }

    public void UseAbility() {
        Debug.Log("I don't know how to choose different abilitiess");
    }
}
