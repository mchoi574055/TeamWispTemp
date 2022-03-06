using Pathfinding;
using UnityEngine;

namespace Behaviours
{
    [RequireComponent(typeof(Seeker))]
    public class FollowPath : MonoBehaviour
    {
        //Constants
        private const float NextWaypointRadius = 0.2f;
        
        // Fields
        private float mSpeed;
        
        // Path Variables
        private Transform[] mPath;
        private int mCurrentPoint;
        private Transform mCurrentGoal;
        
        // Astar Variables
        private Path path;
        private int currentWaypoint = 0;
        private Seeker seeker;
        
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
            seeker = GetComponent<Seeker>();
            
            mCurrentGoal = mPath[0];
            
            seeker.StartPath(transform.position, mCurrentGoal.position, p =>
            {
                path = p;
                currentWaypoint = 0;
            });
        }

        private void Update()
        {
            if (path == null) return;
            
            if (currentWaypoint >= path.vectorPath.Count || Vector3.Distance(transform.position, mCurrentGoal.position) < NextWaypointRadius)
            {
                mDirection = Vector3.zero;
                
                ChangeGoal();
            }
            else
            {
                mDirection = (path.vectorPath[currentWaypoint] - transform.position).normalized;
                
                transform.position = Vector2.MoveTowards(transform.position,
                                    path.vectorPath[currentWaypoint],
                            mSpeed * Time.deltaTime);
                
                float distance = Vector2.Distance(transform.position, path.vectorPath[currentWaypoint]);

                if (distance < NextWaypointRadius)
                {
                    currentWaypoint++;
                }
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
            
            seeker.StartPath(transform.position, mCurrentGoal.position, p =>
            {
                path = p;
                currentWaypoint = 0;
            });
        }
        
        // Getters and setters

        public Vector3 GetDirection()
        {
            return mDirection.magnitude > 0.1 ? mDirection.normalized : Vector3.zero;
        }
    }
}