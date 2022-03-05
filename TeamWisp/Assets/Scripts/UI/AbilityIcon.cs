using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityIcon : MonoBehaviour
{
    Image self;
    [SerializeField] Sprite normalSprite;
    [SerializeField] Sprite pressedSprite;
    [SerializeField] KeyCode ActivationKey;
    private void Start()
    {
        self = GetComponent<Image>();
    }

    public void toggleButtonPress(bool pressed)
    {
        if (pressed)
        {
            self.sprite = pressedSprite;
        } else
        {
            self.sprite = normalSprite;
        }
    }
}
