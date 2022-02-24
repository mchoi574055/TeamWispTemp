using System;
using UnityEngine;

namespace Behaviours
{
    public class Encircle : MonoBehaviour
    {
        // Fields
        private GameObject mTarget;
        private float mSpeed;

        private float mEncirclePos;
        private float mEncircleRadius;

        public void Init(GameObject target, float speed)
        {
            mTarget = target;
            mSpeed = speed;

            mEncircleRadius = Vector2.Distance(transform.position, mTarget.transform.position);

            enabled = false;
        }
    
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            mEncirclePos = (mEncirclePos += Time.deltaTime) % (float)(2 * Math.PI * mEncircleRadius);
            Vector3 circlePos = new Vector2(mEncircleRadius * (float) Math.Cos(mEncircleRadius/mEncirclePos), 
                mEncircleRadius * (float) Math.Sin(mEncircleRadius/mEncirclePos));
            transform.position = Vector2.MoveTowards(transform.position, 
                mTarget.transform.position + circlePos, 
                mSpeed * Time.deltaTime);
        }

    }
}