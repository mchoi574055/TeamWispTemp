using UnityEngine;

namespace Menus
{
    public class CameraDrift : MonoBehaviour
    {
        private bool drifting = false;

        private float time;
    
        void Start()
        {
        
        }
    
        void Update()
        {
            time = (time += Time.deltaTime/5f) % 360;
        
            if (drifting)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(Mathf.Cos(time/1.02f) * 2.5f, Mathf.Sin(time) * 2.5f, 0), Time.deltaTime);
            }
            else
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.identity, Time.deltaTime * 4f);
            }
        }

        public void SetDrift(bool b)
        {
            drifting = b;
        }
    }
}
