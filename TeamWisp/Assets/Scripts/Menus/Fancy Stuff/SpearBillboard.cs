using UnityEngine;

namespace Menus
{
    public class SpearBillboard : MonoBehaviour
    {
        [SerializeField] private GameObject mCamera;
        
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            transform.LookAt(mCamera.transform);
        }
    }
}
