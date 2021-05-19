using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
    public class AllHelperFunctions 
    {
        public static string whereIsObject(Transform selfObject, Transform targetObject, bool rightLeft = true)
        {
            Vector3 targetDirectionLocal = selfObject.InverseTransformPoint(targetObject.position);

            if ( ! rightLeft )
            {
                if (targetDirectionLocal.y > 0) return ("up");
                else if (targetDirectionLocal.y < 0) return ("down");
            }

            if (targetDirectionLocal.x < 0) return "left";
            else return "right";
        }
    }
}