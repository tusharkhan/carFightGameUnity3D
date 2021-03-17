using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car { 
    public class CarGun : MonoBehaviour
    {
        public Transform leftGunHolder;
        public Transform rightGunHolder;

        public Transform leftSpwonPosition;
        public Transform rightSpwonPosition;

        public GameObject gunBullet;

        private CarGunHelper gunHelper;

        // Start is called before the first frame update
        void Start()
        {
            gunHelper = new CarGunHelper();
            gunHelper.rotateSpeed = 7;
            gunHelper.bulletSpeed = 150f;
        }

        // Update is called once per frame
        void Update()
        {
            rotateHolders();
            fire();
        }


        private void fire()
        {
            if (Input.GetButton("Fire1"))
            {
                gunHelper.moveBullet(gunBullet, leftSpwonPosition);
                gunHelper.moveBullet(gunBullet, rightSpwonPosition);
            }
        }


       private void rotateHolders()
       {
            gunHelper.rotateWithMouseScroll(leftGunHolder);
            gunHelper.rotateWithMouseScroll(rightGunHolder);
       }
    }
}