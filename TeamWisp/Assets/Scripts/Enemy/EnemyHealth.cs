using System.Collections;
using System.Collections.Generic;
using Enemy;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float Hitpoints;
    [SerializeField] float MaxHitpoints = 5;
    [SerializeField] HealthBar Healthbar;
    // Start is called before the first frame update
    void Start()
    {
        Hitpoints = MaxHitpoints;
        Healthbar.SetHealth(Hitpoints,MaxHitpoints);
    }

    public void UpdateHealth(float damage)
    {
        Hitpoints += damage;
        Healthbar.SetHealth(Hitpoints,MaxHitpoints);
        if(Hitpoints <= 0)
        {
            Destroy(gameObject);
        }
    }
}
