using System;
using UnityEngine;

namespace Behaviours
{
    public class Encircle : MonoBehaviour
    {
        private bool initialized = false;
        
        // Fields
        private GameObject mTarget;
        private float mSpeed;

        private float mEncirclePos;
        private float mEncircleRadius;
        private bool mClockwise = false;
            
        private Vector3 mDirection = Vector3.zero;

        public void Init(GameObject target, float speed)
        {
            mTarget = target;
            mSpeed = speed;

            initialized = true;
            enabled = false;
        }

        // Lifecycle
        private void OnEnable()
        {
            if (!initialized) return;
            
            mEncircleRadius = Vector3.Distance(transform.position, mTarget.transform.position);
            mEncirclePos = Mathf.Deg2Rad * -Vector3.SignedAngle(transform.position - mTarget.transform.position, Vector3.right, Vector3.forward) * mEncircleRadius;
        }

        void Start()
        {
        
        }

        void Update()
        {
            mDirection = (mTarget.transform.position - transform.position);
            
            Vector3 circlePos = new Vector3(mEncircleRadius * Mathf.Cos(mEncirclePos/mEncircleRadius), 
                mEncircleRadius * Mathf.Sin(mEncirclePos/mEncircleRadius), 0);
            transform.position = Vector3.MoveTowards(transform.position, mTarget.transform.position + circlePos, mSpeed * Time.deltaTime);

            if (transform.position == mTarget.transform.position + circlePos)
            {
                mEncirclePos += (mClockwise ? -1 : 1) * (mSpeed * Time.deltaTime);
                mEncirclePos %= (Mathf.PI * 2 * mEncircleRadius);
            }
        }
        
        // Events

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.layer == LayerMask.NameToLayer("Objects"))
            {
                mClockwise = !mClockwise;
                
                mEncirclePos += (mClockwise ? -1 : 1) * 90;
                mEncirclePos %= (Mathf.PI * 2 * mEncircleRadius);
            }
        }

        // Getters and setters
        public bool IsClockwise()
        {
            return mClockwise;
        }

        public void SetClockwise(bool clockwise)
        {
            mClockwise = clockwise;
        }

        public Vector3 GetDirection()
        {
            return mDirection.magnitude > 0.1 ? mDirection.normalized : Vector3.zero;
        }
        
    }
}