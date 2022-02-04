using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    private float health = 0f;
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private Slider healthSlider;

    // Start is called before the first frame update
    private void Start(){
        health = maxHealth;
        healthSlider.maxValue = maxHealth;
    }

    public void UpdateHealth(float mod){
        health += mod;

        if(health > maxHealth){
            health = maxHealth;
        } else if (health <= 0f){
            health = 0f;
            Debug.Log("Player Dead");

            // Player Dead
            GameObject player = GameObject.FindWithTag("Player");

            player.GetComponent<SpriteRenderer>().color = new Color(0,0,0,1);
            player.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);

            player.GetComponent<PlayerMovement>().enabled = false;
        }
    }

    private void OnGUI(){
        healthSlider.value = health;
    }
}
