using System.Collections;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
    public class CarCanonBullet : MonoBehaviour
    {
        private Transform target;
        private float enemyCarLayer = 12f;
        private float carCanonDamage = 30f;
        private float movementTime = 0;
        private MakeAudioSource makeAudio;

        public AudioSource audioSource;
        public BulletHelper bulletHelper;
        // Use this for initialization
        void Start()
        {
            bulletHelper = new BulletHelper();
            makeAudio = new MakeAudioSource();
        }


        private void Awake()
        {
            audioSource.Play();
        }


        // Update is called once per frame
        void Update()
        {
            if (target == null) return;

            movementTime += Time.deltaTime;

            if (movementTime >= 4f)
            {
                bulletHelper.destroyObject(gameObject);
                return;
            }

            moveCanonBullet();
        }


        public void setTarget(Transform targetTransform)
        {
            target = targetTransform;
        }

        public Transform getTarget()
        {
            return target;
        }


        private void moveCanonBullet()
        {
            transform.LookAt(getTarget().position);
            transform.Rotate(new Vector3(-90, getTarget().rotation.y, getTarget().rotation.z));
            transform.position = Vector3.MoveTowards(transform.position, getTarget().position, Time.deltaTime * 10);
        }


        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.layer == enemyCarLayer)
            {
                bulletHelper.searchAndDestroy(collision.gameObject, "EnemyCar", gameObject, carCanonDamage);
            }
        }

    }
}