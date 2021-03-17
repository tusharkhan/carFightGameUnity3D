using System.Collections;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof (CarController))]
    public class CarUserControl : MonoBehaviour
    {
        private CarController m_Car; // the car controller we want to use
        private float shieldCounter = 0;
        private float shieldResolveCounter = 0;
        [SerializeField]
        private float shieldCounterLinit = 9;
        [SerializeField]
        private float shieldResolveCounterLinit = 15;
        [SerializeField]
        private float physicsColliderArea = 4f;

        public ParticleSystem shieldParticle;

        private void Awake()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();
            //shieldParticle.Stop();
        }


        private void FixedUpdate()
        {
            // pass the input to the car!
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            float v = CrossPlatformInputManager.GetAxis("Vertical");

            makeShield();
#if !MOBILE_INPUT
            float handbrake = CrossPlatformInputManager.GetAxis("Jump");
            m_Car.Move(h, v, v, handbrake);
#else
            m_Car.Move(h, v, v, 0f);
#endif
        }


        public void makeShield()
        {
            shieldParticle.transform.position = transform.position;
            if (getShieldResolveCounter() >= (shieldResolveCounterLinit + 1) )
            {
                if (Input.GetKey(KeyCode.E))
                {
                    shieldActiveCounterStart();
                    if (getShieldCounter() <= shieldCounterLinit)
                    {
                        activateShield();
                        makeCollider();
                    }
                    else
                    {
                        deactivateShield();
                        stopShieldResolveCounter();
                    }
                }
                else if (Input.GetKeyUp(KeyCode.E))
                {
                    stopShieldResolveCounter();
                }
            }
            else
            {
                deactivateShield();
                shieldResolveCounterStart();
            }
        }


        private void activateShield()
        {
            shieldParticle.gameObject.SetActive(true);
        }


        private void shieldActiveCounterStart()
        {
            shieldCounter += Time.deltaTime;
        }



        private void deactivateShield()
        {
            stopShieldCounter();
            shieldParticle.gameObject.SetActive(false);
        }


        private void stopShieldCounter()
        {
            shieldCounter = 0;
        }


        private void stopShieldResolveCounter()
        {
            shieldResolveCounter = 0;
        }


        private float getShieldResolveCounter()
        {
            return shieldResolveCounter;
        }


        private float getShieldCounter()
        {
            return shieldCounter;
        }


        private void shieldResolveCounterStart()
        {
            shieldResolveCounter += Time.deltaTime;
        }


        private void makeCollider()
        {
            Collider[] hitColliders =  Physics.OverlapSphere(transform.position, physicsColliderArea);

            foreach (Collider collider in hitColliders)
            {
                GameObject hitGameObject = collider.gameObject;
                if (hitGameObject.tag == "EnemyBullet")
                {
                    Bullet enemyBullet = collider.gameObject.GetComponent<Bullet>();
                    enemyBullet.bulletHelper.destroyObject(enemyBullet.gameObject);
                }
                else if (hitGameObject.tag == "EnemyCanonBullet")
                {
                    EnemyCanonBullet enemyBullet = collider.gameObject.GetComponent<EnemyCanonBullet>();
                    enemyBullet.bulletHelper.destroyObject(enemyBullet.gameObject);
                }
            }
        }
    }
}
