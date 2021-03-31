using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
    public class EnemyCarHelper : MonoBehaviour
    {
        private Transform target;
        private CarAIControl carAIControl;
        private float activateDistance = 10f;

        // Use this for initialization
        void Start()
        {
            carAIControl = GetComponent<CarAIControl>();
            target = GameObject.Find("Target").transform;
            //carAIControl.setDriving(true);
        }

        // Update is called once per frame
        void Update()
        {
            //isNearPlayerCar();
        }


        public bool isNear(Vector3 positionOne, Vector3 positionTwo, float targetDistance)
        {
            float sqrt = (positionOne - positionTwo).sqrMagnitude;
            return (Mathf.Pow(targetDistance, 2) >= sqrt);
        }


        private void isNearPlayerCar()
        {
            if(isNear(target.position, transform.position, activateDistance))
            {
                carAIControl.setDriving(false);
            } else
            {
                carAIControl.setDriving(true);
            }
        }
    }
}