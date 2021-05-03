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
        public AudioSource explotionAudioSource;

        private Camera mainCam;
        public bool isDead = false;

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
            if ( ! isDead )
            {
                destroyAllComponents();

                if (gameObject.name == "Car") updateCarHealth();
                else if (gameObject.name == "EnemyCar") updateEnemyHealth();
            }
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
            if (healthHelper.getCurentHealth() <= 0 && !isDead)
            {
                playExplotionAudio();
                //stopAll();
                explotionParticleSystem.Play();
                healthSlider.gameObject.SetActive(false);
                isDead = true;
            }
        }


        private void stopAll()
        {
            if (gameObject.tag == "Player")
            {
                GameObject[] allEnemyCar = GameObject.FindGameObjectsWithTag("Enemy");

                if(allEnemyCar.Length > 0)
                {
                    foreach (GameObject gameObjectEnemy in allEnemyCar)
                    {
                        if (gameObjectEnemy != null)
                        {
                            gameObjectEnemy.GetComponent<CarAIControl>().stopCarAi();
                            gameObjectEnemy.GetComponent<EnemyGun>().stopShooting();
                        }
                        else break;
                    }
                }
            } 

            //if( gameObject.tag == "Player")
            //{
            //    GameObject playerCar = GameObject.FindGameObjectWithTag("Player");

            //    playerCar.GetComponent<CarController>().enabled = false;
            //    playerCar.GetComponent<CarUserControl>().enabled = false;
            //    playerCar.GetComponent<CarAudio>().enabled = false;
            //    playerCar.GetComponent<CarGun>().enabled = false;
            //}
        }


        private void playExplotionAudio()
        {
            explotionAudioSource.Play();
        }
    }
}