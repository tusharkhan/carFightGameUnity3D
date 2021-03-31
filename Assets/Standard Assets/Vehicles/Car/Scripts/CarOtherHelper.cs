using System.Collections;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
    public class CarOtherHelper : MonoBehaviour
    {
        private float NOSCounter = 0;
        private float NOSInterval = 1.8f;

        public ParticleSystem leftNOS;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            rotateNOS();            
        }


        private void rotateNOS()
        {
            leftNOS.transform.localRotation = transform.rotation;
            Debug.Log(leftNOS.transform.localRotation);
            //Debug.Log(transform.rotation);
        }
    }
}