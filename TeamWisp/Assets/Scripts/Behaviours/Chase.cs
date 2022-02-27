using UnityEngine;

namespace Behaviours
{
    public class Chase : MonoBehaviour
    {
        // Fields
        private GameObject mTarget;
        private float mSpeed;
        
        private Vector3 mDirection = Vector3.zero;

        public void Init(GameObject target, float speed)
        {
            mTarget = target;
            mSpeed = speed;

            enabled = false;
        }
        
        // Lifecycle
        void Start()
        {
        
        }

        void Update()
        {
            mDirection = (mTarget.transform.position - transform.position).normalized;
            
            transform.position = Vector2.MoveTowards(transform.position, 
                mTarget.transform.position, mSpeed * Time.deltaTime);
        }
        
        // Getters and setters

        public Vector3 GetDirection()
        {
            return mDirection;
        }
    }
}
