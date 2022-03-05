using System.Collections;
using System.Collections.Generic;
using Enemy;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float invincibilityTime;
    private bool hasIFrames = false;
    
    [SerializeField] int health;
    [SerializeField] int maxHealth = 5;
    [SerializeField] HealthBar Healthbar;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        Healthbar.SetHealth(health,maxHealth);
    }

    public void Damage(int damage)
    {
        if (hasIFrames) return;

        hasIFrames = true;
        
        health -= damage;
        Healthbar.SetHealth(health,maxHealth);
        GetComponent<Animator>().Play("Stagger");
        
        StartCoroutine(StopIFrames());
        
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator StopIFrames()
    {
        yield return new WaitForSeconds(invincibilityTime);
        hasIFrames = false;
    }
}
