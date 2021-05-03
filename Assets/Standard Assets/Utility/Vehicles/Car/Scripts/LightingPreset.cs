using System.Collections;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
    [System.Serializable]
    [CreateAssetMenu(fileName ="Ligthtinng Preset", menuName = "Scriptable/LightningPreset", order =1)]
    public class LightingPreset : ScriptableObject
    {
        public Gradient ambeinColor;
        public Gradient directonalLightColor;
        public Gradient fogColor;
         
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}