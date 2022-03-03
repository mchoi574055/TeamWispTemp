using Pathfinding;
using UnityEngine;

namespace Behaviours
{
    [RequireComponent(typeof(Seeker))]
    public class Chase : MonoBehaviour
    {
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

            enabled = false;
        }
        
        // Lifecycle
        void Start()
        {
            seeker = GetComponent<Seeker>();
            
            InvokeRepeating(nameof(UpdatePath), 0f, 0.5f);
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
            
            seeker.StartPath(transform.position, mTarget.transform.position, p =>
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
