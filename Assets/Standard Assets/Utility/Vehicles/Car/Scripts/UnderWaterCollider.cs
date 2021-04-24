using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
    public class UnderWaterCollider : MonoBehaviour
    {
        public LayerMask layerMask;
        public GameObject car;

        private bool isCollidingWithCar = false;
        private CarAudio carAudio;
        // Start is called before the first frame update
        void Start()
        {
            carAudio = car.GetComponent<CarAudio>();
        }

        // Update is called once per frame
        void Update()
        {
            detectCollutionWithCars();
            changeSound();
        }


        private void detectCollutionWithCars()
        {
            Vector3 size = new Vector3(99f, 12f, 88);
            Collider[] boxColliders = Physics.OverlapBox(transform.position, size / 2);

            foreach(Collider underEaterColliders in boxColliders)
            {
                GameObject collideGameobject = underEaterColliders.gameObject;
                if (collideGameobject.layer == 9) isCollidingWithCar = true;
                else isCollidingWithCar = false;
            }
        }


        private void changeSound()
        {
            if (isCollidingWithCar) carAudio.setPitchMultiplier(0.5f);
            else carAudio.setPitchMultiplier(1f);
        }
    }
}