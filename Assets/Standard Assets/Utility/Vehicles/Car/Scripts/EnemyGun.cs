using UnityEngine;
using System;

namespace UnityStandardAssets.Vehicles.Car
{
    public class EnemyGun : MonoBehaviour
    {
        public Transform leftGunHoler;
        public Transform rightGunHoler;

        public Transform leftSpwonPoint;
        public Transform rightSpwonPoint;
        public Transform canonBulletSpwonPoint;

        public GameObject bullet;
        public GameObject canonBullet;

        public GameObject leftMuzzleFlash;
        public GameObject rightMuzzleFlash;

        public AudioSource audioSource;

        private CarGunHelper gunHelper;
        private Transform target;

        private EnemyCarHelper enemyCarHelper;

        private float currentTimeForBullet = 0f;
        private float currentTimeForCanon = 0f;
        private bool playerDied = false;
        private float maxDistance = 30f;
        private CarHelper carHelper;


        // Start is called before the first frame update
        void Start()
        {
            carHelper = GetComponent<CarHelper>();
            gunHelper = new CarGunHelper();
            gunHelper.rotateSpeed = 9;
            gunHelper.timeIntervalBullet = 0.6f;
            gunHelper.timeIntervalCanonBullet = 5f;
            gunHelper.bulletSpeed = 150f;
            target = GameObject.Find("Target").transform;

            enemyCarHelper = new EnemyCarHelper();
        }

        // Update is called once per frame
        void Update()
        {
            string targetPosition = AllHelperFunctions.whereIsObject(transform, target, false);
            if( !playerDied && enemyCarHelper.isNear(transform.position, target.position, maxDistance) && String.Compare("down", targetPosition) != 0)
            {
                rotateHolders();
                playerDied = carHelper.isDead;
            }
        }


        private void rotateHolders()
        {
            if (target == null) return;

            gunHelper.rotate(leftGunHoler, target);
            gunHelper.rotate(rightGunHoler, target);

            fireAll();
        }


        private void shootGun() 
        {
            audioSource.Play();
            gunHelper.moveBullet(bullet, leftSpwonPoint);
            gunHelper.moveBullet(bullet, rightSpwonPoint);
        }



        private void shootCanon()
        {
            gunHelper.makeBullet(canonBullet, canonBulletSpwonPoint);
        }


        private float calculateTimeForCanon()
        {
            return currentTimeForCanon  += Time.deltaTime;
        }

        private float calculateTimeForBullet()
        {
            return currentTimeForBullet += Time.deltaTime;
        }


        private void fireAll()
        {
            if (calculateTimeForBullet() >= gunHelper.timeIntervalBullet)
            {
                shootGun();
                lightMuzzleflash();
                currentTimeForBullet = 0f;
            }
            else stopMuzzleflash();

            if (calculateTimeForCanon() >= gunHelper.timeIntervalCanonBullet)
            {
                Debug.Log("Canon shoot");
                shootCanon();
                currentTimeForCanon = 0;
            }
        }

        public void stopShooting()
        {
            playerDied = true;
        }


        public void startShooting()
        {
            playerDied = false;
        }



        private void lightMuzzleflash()
        {
            leftMuzzleFlash.SetActive(true);
            rightMuzzleFlash.SetActive(true);
        }


        private void stopMuzzleflash()
        {
            leftMuzzleFlash.SetActive(false);
            rightMuzzleFlash.SetActive(false);
        }


        public Transform getTarget()
        {
            if( target == null ) return GameObject.Find("Target").transform;
            return target;
        }
    }
}