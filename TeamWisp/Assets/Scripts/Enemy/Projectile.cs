using UnityEngine;

namespace Behaviours.Attacks
{
    public class Projectile : MonoBehaviour
    {
        private bool initialized = false;
        
        // Member Variables
        // TODO Add heroController
        private GameObject hero;
        private float mSpeed;
        private float mDistance;
        private Vector3 mDirection;
        private Vector3 mStartPosition;

        public void Init(float speed, float distance)
        {
            mSpeed = speed;
            mDistance = distance;

            initialized = true;
        }
    
        // Lifecycle
        void Start()
        {
            hero = GameObject.FindGameObjectWithTag("Hero");
            mDirection = (hero.transform.position - transform.position).normalized;
            mStartPosition = transform.position;
        }
        
        void Update()
        {
            if (initialized)
            {
                transform.position += (mDirection * mSpeed * Time.deltaTime);

                if (Vector3.Distance(transform.position, mStartPosition) >= mDistance)
                {
                    DestroyProjectile();
                }
            }
        }

        // Events
        void OntriggerEnter2D(Collider2D other){
            if(other.CompareTag("Hero")){
                DestroyProjectile();
            }
        }

        // Methods
        void DestroyProjectile(){
            Destroy(gameObject);
        }
    }
}
