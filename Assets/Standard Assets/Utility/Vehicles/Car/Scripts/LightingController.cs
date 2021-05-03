using System.Collections;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
    [ExecuteAlways]
    public class LightingController : MonoBehaviour
    {
        [SerializeField] private Light DirectionalLight;
        [SerializeField] private LightingPreset Preset;
        [SerializeField, Range(0, 24)] private float TimeOfDay;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Preset == null) return;

            if (Application.isPlaying)
            {
                TimeOfDay += 0.0009f;
                TimeOfDay %= 24;
                updateLightning(TimeOfDay / 24);
            } else updateLightning(TimeOfDay / 24);
        }


        private void OnValidate()
        {
            if (DirectionalLight != null) return;

            if (RenderSettings.sun != null) DirectionalLight = RenderSettings.sun;
            else
            {
                Light[] lights = GameObject.FindObjectsOfType<Light>();

                foreach(Light light in lights)
                {
                    if( light.type == LightType.Directional)
                    {
                        DirectionalLight = light;
                        return;
                    }
                }
            }
        }



        private void updateLightning(float time)
        {
            RenderSettings.ambientLight = Preset.ambeinColor.Evaluate(time);
            RenderSettings.fogColor = Preset.fogColor.Evaluate(time);

            if( DirectionalLight != null)
            {
                DirectionalLight.color = Preset.directonalLightColor.Evaluate(time);
                DirectionalLight.transform.localRotation = Quaternion.Euler( 
                    new Vector3((time * 360f)-90f, 170, 0)
                    );
            }
        }
    }
}