using System.Collections;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
    public class EnvirnmentMainController : MonoBehaviour
    {
        public Transform directionalLiteAsSun;
        public float sunRotationSpeed = 1f;

        // Use this for initialization
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            updateSun();
        }


        public void updateSun()
        {
            directionalLiteAsSun.localEulerAngles = new Vector3(Time.time * sunRotationSpeed, -30, 0);
            RenderSettings.skybox.SetFloat("_Rotation", (Time.time * sunRotationSpeed));
        }
    }
}