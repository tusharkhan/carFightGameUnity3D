using UnityEngine.UI;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
    public class CarHelper : MonoBehaviour
    {
        public HealthHelper healthHelper;
        public Slider healthSlider;
        public float carMaxHealth;
        public ParticleSystem explotionParticleSystem;

        private Camera mainCam;

        // Use this for initialization
        void Start()
        {
            healthHelper = new HealthHelper();
            setInitHealth();
            explotionParticleSystem.Stop();
            mainCam = Camera.main;
        }

        // Update is called once per frame
        void Update()
        {
            destroyAllComponents();

            if (gameObject.name == "Car") updateCarHealth();
            else if (gameObject.name == "EnemyCar") updateEnemyHealth(); 
        }


        private void setInitHealth()
        {
            healthHelper.setMaxHealth(carMaxHealth);
            healthHelper.setCurrentHealth(healthHelper.getMaxHealth());
            healthSlider.maxValue = healthHelper.getMaxHealth();
            healthSlider.value = healthHelper.getMaxHealth();
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


        private void destroyAllComponents()
        {
            if (healthHelper.getCurentHealth() <= 0)
            {
                stopAllEnemy();
                explotionParticleSystem.Play();
                healthSlider.gameObject.SetActive(false);
                foreach (var comp in gameObject.GetComponents<Component>())
                {
                    if (
                        !(comp is Transform) &&
                        !(comp is CarController)
                        )
                    {
                        Destroy(comp);
                    }
                }
            }
        }


        private void stopAllEnemy()
        {
            if (gameObject.tag == "Player")
            {
                GameObject[] allEnemyCar = GameObject.FindGameObjectsWithTag("Enemy");

                foreach (GameObject gameObjectEnemy in allEnemyCar)
                {
                    gameObjectEnemy.GetComponent<CarAIControl>().stopCarAi();
                    gameObjectEnemy.GetComponent<EnemyGun>().stopShooting();
                }
            }
        }
    }
}