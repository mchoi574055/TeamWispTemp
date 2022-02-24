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
        
        private Vector3 mDirection = Vector3.zero;

        public void Init(GameObject target, float speed)
        {
            mTarget = target;
            mSpeed = speed;

            initialized = true;
            enabled = false;
        }

        private void OnEnable()
        {
            if (!initialized) return;
            
            Debug.Log(Vector3.SignedAngle(transform.position - mTarget.transform.position, Vector3.right, Vector3.forward));
            mEncircleRadius = Vector3.Distance(transform.position, mTarget.transform.position);
            mEncirclePos = Mathf.Deg2Rad * -Vector3.SignedAngle(transform.position - mTarget.transform.position, Vector3.right, Vector3.forward) * mEncircleRadius;
        }

        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            mDirection = (mTarget.transform.position - transform.position).normalized;
            
            Vector3 circlePos = new Vector3(mEncircleRadius * (float) Math.Cos(mEncirclePos/mEncircleRadius), 
                mEncircleRadius * (float) Math.Sin(mEncirclePos/mEncircleRadius), 0);
            transform.position = Vector3.MoveTowards(transform.position, mTarget.transform.position + circlePos, mSpeed * Time.deltaTime);

            if (transform.position == mTarget.transform.position + circlePos)
            {
                mEncirclePos += mSpeed * Time.deltaTime;
            }
        }
        
        // Getters and setters

        public Vector3 GetDirection()
        {
            return mDirection;
        }

    }
}