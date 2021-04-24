using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
    public class EnemyCarHelper : MonoBehaviour
    {
        public bool isNear(Vector3 positionOne, Vector3 positionTwo, float targetDistance)
        {
            float sqrt = (positionOne - positionTwo).sqrMagnitude;
            return (Mathf.Pow(targetDistance, 2) >= sqrt);
        }
        
    }
}