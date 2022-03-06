using Hero;
using UnityEngine;

namespace Enemy.Apple.Collider
{
    public class AppleCollider : MonoBehaviour
    {
        private AppleController appleController;
    
        private GameObject hero;
        private HeroController heroController;
    
        // Start is called before the first frame update
        void Start()
        {
            hero = GameObject.FindGameObjectWithTag("Hero");
            heroController = hero.GetComponent<HeroController>();

            appleController = GetComponentInParent<AppleController>();
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    
        // Events

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Hero"))
            {
                if (GetComponentInParent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Charge Action"))
                {
                    heroController.Damage(appleController.GetChargeDamage());
                }
                else
                {
                    heroController.Damage(appleController.GetContactDamage());
                }
            }
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.CompareTag("Hero"))
            {
                Vector3 knockbackDirection = (other.transform.position - transform.position).normalized;
                other.transform.position += knockbackDirection * Time.deltaTime;
                
                GetComponentInParent<Animator>().Play("Back Off");
            }
        }
    }
}
