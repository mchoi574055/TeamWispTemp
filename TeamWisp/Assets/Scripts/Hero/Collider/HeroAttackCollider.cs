using UnityEngine;

namespace Hero.Collider
{
    public class HeroAttackCollider : MonoBehaviour
    {
        
        protected bool active = false;
        protected int damage;

        public virtual void ToggleCollider(bool state, Vector3 direction)
        {
        
        }

        public bool IsActive()
        {
            return active;
        }
        
        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.CompareTag("Enemy"))
            {
                Vector3 knockbackDirection = (other.transform.position - transform.position).normalized;
                other.transform.position += knockbackDirection * Time.deltaTime;
                EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
                enemyHealth.Damage(damage);
            }
        }
    }
}
