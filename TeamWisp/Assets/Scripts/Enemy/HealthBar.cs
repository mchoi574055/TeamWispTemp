using UnityEngine;
using UnityEngine.UI;

namespace Enemy
{
    public class HealthBar : MonoBehaviour
    {
        public Slider Slider;
        [SerializeField] Color Low;
        [SerializeField] Color High;
        [SerializeField] Vector3 Offset;
        // Start is called before the first frame update

        public void SetHealth(float health, float maxHealth)
        {
            Slider.gameObject.SetActive(health < maxHealth);
            Slider.value = health;
            Slider.maxValue = maxHealth;

            Slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(Low,High,Slider.normalizedValue);
        }

        // Update is called once per frame
        void Update()
        {
            Slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + Offset);
        }
    }
}
