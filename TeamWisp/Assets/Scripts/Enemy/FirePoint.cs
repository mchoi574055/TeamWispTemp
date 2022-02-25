using UnityEngine;

namespace Enemy
{
    public class FirePoint: MonoBehaviour
    {
        public Projectile projectile;
        [SerializeField] private float startTimeBtwShots = 2f;
        [SerializeField] private float speed = 10f;
        [SerializeField] private float range = 5f;

        private float timeBtwShots;

        // Start is called before the first frame update
        void Start()
        {
            timeBtwShots = startTimeBtwShots;
        }

        // Update is called once per frame
        void Update()
        {
            if(timeBtwShots <= 0){
                Projectile proj = Instantiate(projectile, transform.position, Quaternion.identity);
                proj.Init(speed, range);
                
                timeBtwShots = startTimeBtwShots;
            }else {
                timeBtwShots -= Time.deltaTime;
            }
        }
    }
}
