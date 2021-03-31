using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car { 
    public class CarGun : MonoBehaviour
    {
        public Transform leftGunHolder;
        public Transform rightGunHolder;

        public Transform leftSpwonPosition;
        public Transform rightSpwonPosition;

        public GameObject leftMuzzleFlash;
        public GameObject rightMuzzleFlash;

        public ParticleSystem leftMuzzleFlashParticle;
        public ParticleSystem rightMuzzleFlashParticle;

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
                playAllMuzzleflash();
            }
            else stopAllMuzzleflash();
        }


        private void playAllMuzzleflash()
        {
            lightMuzzleflash();
            lightMuzzleflashParticle();
        }


        private void stopAllMuzzleflash()
        {
            stopMuzzleflash();
            stopMuzzleflashParticle();
        }

        private void lightMuzzleflashParticle()
        {
            leftMuzzleFlashParticle.Play();
            rightMuzzleFlashParticle.Play();
        }


        private void stopMuzzleflashParticle()
        {
            leftMuzzleFlashParticle.Stop();
            rightMuzzleFlashParticle.Stop();
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


       private void rotateHolders()
       {
            gunHelper.rotateWithMouseScroll(leftGunHolder);
            gunHelper.rotateWithMouseScroll(rightGunHolder);
       }
    }
}