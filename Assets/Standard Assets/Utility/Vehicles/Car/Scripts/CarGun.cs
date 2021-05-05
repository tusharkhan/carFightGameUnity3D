using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car { 
    public class CarGun : MonoBehaviour
    {
        public Transform leftGunHolder;
        public Transform rightGunHolder;

        public Transform[] leftSpwonPosition;
        public Transform[] rightSpwonPosition;

        public GameObject[] leftMuzzleFlash;
        public GameObject[] rightMuzzleFlash;
        public GameObject upperCanonMuzzleFlash;

        public Transform upperCanonMovingPart;
        public Transform upperCanonSpwonPosition;

        public ParticleSystem leftMuzzleFlashParticle;
        public ParticleSystem rightMuzzleFlashParticle;

        public GameObject gunBullet;
        public GameObject upperCanonBullet;
        public AudioSource audioSource;

        private CarGunHelper gunHelper;

        private int enamyLayer = 12;

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
            rotateUpperCanon();
            fire();
        }

        //main fire method
        private void fire()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                for (int i = 0; i < leftSpwonPosition.Length; ++i)
                {
                    gunHelper.moveBullet(gunBullet, leftSpwonPosition[i]);
                    gunHelper.moveBullet(gunBullet, rightSpwonPosition[i]);
                }

                playAllMuzzleflash();
                audioSource.Play();
            }
            else
            {
                stopAllMuzzleflash();
            }
        }


        //Play all muzzleflash
        private void playAllMuzzleflash()
        {
            lightMuzzleflash();
            lightMuzzleflashParticle();
        }


        //Stop all muzzleflash
        private void stopAllMuzzleflash()
        {
            stopMuzzleflash();
            stopMuzzleflashParticle();
        }


        //Canon Muzzleflash show
        private void playCanonMuzzleflash()
        {
            upperCanonMuzzleFlash.SetActive(true);
        }



        //canon muzzleflash stop
        private void stopCanonMuzzleFlash()
        {
            upperCanonMuzzleFlash.SetActive(false);
        }


        //Bullet shell show 
        private void lightMuzzleflashParticle()
        {
            leftMuzzleFlashParticle.Play();
            rightMuzzleFlashParticle.Play();
        }


        //Bullet shell stop
        private void stopMuzzleflashParticle()
        {
            leftMuzzleFlashParticle.Stop();
            rightMuzzleFlashParticle.Stop();
        }


        private void lightMuzzleflash()
        {
            interactWithMuzzleFlash(true);
        }


        private void stopMuzzleflash()
        {
            interactWithMuzzleFlash(false);
        }


        private void interactWithMuzzleFlash(bool isActive)
        {
            for (int i = 0; i < leftMuzzleFlash.Length; ++i)
            {
                leftMuzzleFlash[i].SetActive(isActive);
                rightMuzzleFlash[i].SetActive(isActive);
            }
        }


        //Rotate Gun Holders
       private void rotateHolders()
       {
            gunHelper.rotateWithMouseScroll(leftGunHolder);
            gunHelper.rotateWithMouseScroll(rightGunHolder);
       }


        //Uppr canon fire
        private void rotateUpperCanon()
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, 20, 1 << enamyLayer);

            foreach(Collider collider in colliders)
            {
                if (collider.gameObject.layer == enamyLayer)
                {
                    Transform rootGameObject = collider.gameObject.transform.root;
                    Transform target = rootGameObject.GetChild(0);

                    gunHelper.rotate(upperCanonMovingPart, target.transform);

                    if (Input.GetButtonDown("Fire3"))
                    {
                        playCanonMuzzleflash();
                        GameObject canonBulletUpper = gunHelper.makeBullet(upperCanonBullet, upperCanonSpwonPosition);
                        CarCanonBullet carCanonBullet = canonBulletUpper.GetComponent<CarCanonBullet>();

                        carCanonBullet.setTarget(target);
                    } else stopCanonMuzzleFlash();

                    break;
                }
            }
        }
    }
}