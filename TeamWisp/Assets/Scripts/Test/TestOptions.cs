using UnityEngine;

namespace Test
{
    public class TestOptions : MonoBehaviour
    {
        [SerializeField] private GameObject fakeOption;
        [SerializeField] private float spread;
        [SerializeField] private float centerAngle;
        [SerializeField] private float radius;

        private int[] options = {1,2,3,4};

        // Start is called before the first frame update
        void Start()
        {
            float angle = centerAngle - (options.Length-1)*spread/2;
            for (int i = 0; i < options.Length; i++)
            {
                Vector3 offset = new Vector3(Mathf.Cos(Mathf.Deg2Rad * angle), Mathf.Sin(Mathf.Deg2Rad * angle), 0) * radius;
                GameObject newOption = Instantiate(fakeOption, offset, Quaternion.identity, transform);
                
                newOption.GetComponent<FakeOption>().SetValue(options[i]);

                angle += spread;
            }
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
