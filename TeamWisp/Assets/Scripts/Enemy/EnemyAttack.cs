using System.Collections;
using System.Collections.Generic;
using Hero;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float attackDamage = 10f;
    [SerializeField] private float attackSpeed = 0.5f;
    [SerializeField] private float knockbackPower = 100f;
    [SerializeField] private float knockbackDuration = 1f;
    //[SerializeField] private float knockbackDuration = 1f;

    private float canAttack = 1f;

    private void OnCollisionStay2D(Collision2D other) {
        if(other.gameObject.CompareTag("Hero")){
            if(canAttack >= attackSpeed){
                other.gameObject.GetComponent<HeroHealth>().UpdateHealth(-attackDamage);
                canAttack = 0f;

            }
            else{
                canAttack += Time.deltaTime;
            }
        }
    }
}
