using UnityEngine.UI;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
    public class CarHelper : MonoBehaviour
    {
        public HealthHelper healthHelper;
        public Slider healthSlider;
        public float carMaxHealth;

        private Camera mainCam;

        // Use this for initialization
        void Start()
        {
            healthHelper = new HealthHelper();
            healthHelper.setMaxHealth(carMaxHealth);
            healthHelper.setCurrentHealth( healthHelper.getMaxHealth() );
            healthSlider.maxValue = healthHelper.getMaxHealth();
            healthSlider.value = healthHelper.getMaxHealth();

            mainCam = Camera.main;
        }

        // Update is called once per frame
        void Update()
        {
            if (gameObject.name == "Car") updateCarHealth();
            else if (gameObject.name == "EnemyCar") updateEnemyHealth(); 
        }


        private void updateCarHealth()
        {
            healthSlider.value = healthHelper.getCurentHealth();
        }


        private void updateEnemyHealth()
        {
            healthSlider.transform.LookAt(mainCam.transform);
            healthSlider.value = healthHelper.getCurentHealth();
        }
    }
}