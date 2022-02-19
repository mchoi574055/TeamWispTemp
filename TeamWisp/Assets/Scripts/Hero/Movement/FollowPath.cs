using UnityEngine;

namespace Hero.Movement
{
    public class FollowPath : MonoBehaviour
    {

        public Transform[] path;
        public int currentPoint;
        public Transform currentGoal;
        public float margin = 0.2f;
        public float speed;

        public Vector3 direction = Vector3.zero;
        // Start is called before the first frame update
        void Start()
        {
            currentGoal = path[0];
        }

        // Update is called once per frame
        void Update()
        {
            if (Vector3.Distance(transform.position, currentGoal.position) <= margin)
            {
                changeGoal();
            }
            else
            {
                direction = (currentGoal.position - transform.position).normalized;

                transform.position = Vector3.MoveTowards(transform.position,
                    currentGoal.position,
                    speed * Time.deltaTime);
            }

        }

        private void changeGoal()
        {
            if (currentPoint == path.Length - 1)
            {
                currentPoint = 0;
                currentGoal = path[0];
            }
            else
            {
                currentPoint++;
                currentGoal = path[currentPoint];
            }
        }
    }
}