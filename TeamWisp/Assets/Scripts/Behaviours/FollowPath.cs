using UnityEngine;

namespace Behaviours
{
    public class FollowPath : MonoBehaviour
    {
        //Constants
        private const float Margin = 0.2f;
        
        //Fields
        private Transform[] mPath;
        private float mSpeed;
        
        //Member variables
        private int mCurrentPoint;
        private Transform mCurrentGoal;
        
        public Vector3 mDirection = Vector3.zero;

        public void Init(Transform[] path, float speed)
        {
            mPath = path;
            mSpeed = speed;
            
            enabled = false;
        }
        
        // Lifecycle
        void Start()
        {
            mCurrentGoal = mPath[0];
        }

        private void Update()
        {
            if (Vector3.Distance(transform.position, mCurrentGoal.position) <= Margin)
            {
                ChangeGoal();
            }
            else
            {
                mDirection = (mCurrentGoal.position - transform.position).normalized;
                
                transform.position = Vector2.MoveTowards(transform.position,
                                    mCurrentGoal.position,
                            mSpeed * Time.deltaTime);
            }

        }
        
        // Methods
        private void ChangeGoal()
        {
            if (mCurrentPoint == mPath.Length - 1)
            {
                mCurrentPoint = 0;
                mCurrentGoal = mPath[0];
            }
            else
            {
                mCurrentPoint++;
                mCurrentGoal = mPath[mCurrentPoint];
            }
        }
        
        // Getters and setters

        public Vector3 GetDirection()
        {
            return mDirection;
        }
    }
}