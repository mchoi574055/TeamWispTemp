using UnityEngine;

namespace Behaviours
{
    public class Chase : MonoBehaviour
    {
        // Fields
        private GameObject mTarget;
        private float mSpeed;

        public void Init(GameObject target, float speed)
        {
            mTarget = target;
            mSpeed = speed;
        }
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            transform.position = Vector2.MoveTowards(transform.position, 
                mTarget.transform.position, mSpeed * Time.deltaTime);
        }
    }
}
