using UnityEngine;
using UnityEngine.UI;

namespace Hero
{
    public class HeroHealth : MonoBehaviour
    {

        private float health = 0f;
        [SerializeField] private float maxHealth = 100f;
        [SerializeField] private Slider healthSlider;

        // Start is called before the first frame update
        private void Start(){
            health = maxHealth;
            healthSlider.maxValue = maxHealth;
        }

        public void UpdateHealth(float mod){
            health += mod;

            if(health > maxHealth){
                health = maxHealth;
            } else if (health <= 0f){
                health = 0f;
                Debug.Log("Hero Dead");

                // Hero Dead
                GameObject hero = GameObject.FindWithTag("Hero");

                hero.GetComponent<SpriteRenderer>().color = new Color(0,0,0,1);
                hero.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);

                //hero.GetComponent<PlayerMovement>().enabled = false;
            }
        }

        private void OnGUI(){
            healthSlider.value = health;
        }
    }
}
