using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        private CarGunHelper gunHelper;
        private Transform target;
        private float currentTimeForBullet = 0f;
        private float currentTimeForCanon = 0f;


        // Start is called before the first frame update
        void Start()
        {
            gunHelper = new CarGunHelper();
            gunHelper.rotateSpeed = 9;
            gunHelper.timeIntervalBullet = 0.8f;
            gunHelper.timeIntervalCanonBullet = 5f;
            gunHelper.bulletSpeed = 150f;
            target = GameObject.Find("Target").transform;
        }

        // Update is called once per frame
        void Update()
        {
            rotateHolders();
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
                currentTimeForBullet = 0f;
            }

            if (calculateTimeForCanon() >= gunHelper.timeIntervalCanonBullet)
            {
                shootCanon();
                currentTimeForCanon = 0;
            }
        }
    }
}