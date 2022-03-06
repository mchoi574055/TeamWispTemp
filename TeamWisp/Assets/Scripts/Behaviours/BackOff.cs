using Pathfinding;
using UnityEngine;

namespace Behaviours
{
    public class BackOff : MonoBehaviour
    {
        private bool initialized = false;
        
        //Constants
        private const float NextWaypointRadius = 0.2f;
        
        // Fields
        private GameObject mTarget;
        private float mSpeed;
        
        // Astar Variables
        private Path path;
        private int currentWaypoint = 0;
        private Seeker seeker;
        
        private Vector3 mDirection = Vector3.zero;

        public void Init(GameObject target, float speed)
        {
            mTarget = target;
            mSpeed = speed;

            initialized = true;
            enabled = false;
        }
        
        // Lifecycle
        void Start()
        {
            seeker = GetComponent<Seeker>();

            mDirection = (mTarget.transform.position - transform.position);
            
            UpdatePath();
        }

        void Update()
        {
            if (path == null) return;

            if (currentWaypoint >= path.vectorPath.Count) return;

            mDirection = (mTarget.transform.position - transform.position);
            
            transform.position = Vector2.MoveTowards(transform.position, 
                path.vectorPath[currentWaypoint], 
                mSpeed * Time.deltaTime);
            
            float distance = Vector2.Distance(transform.position, path.vectorPath[currentWaypoint]);

            if (distance < NextWaypointRadius)
            {
                currentWaypoint++;
            }
        }

        // Methods

        private void UpdatePath() 
        {
            if (!seeker.IsDone()) return;
            
            seeker.StartPath(transform.position, mTarget.transform.position + mDirection.normalized * 5, p =>
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

        public void UpdateTarget(GameObject target)
        {
            mTarget = target;
        }

        public bool Complete()
        {
            return initialized && currentWaypoint >= path.vectorPath.Count;
        }
    }
}
