using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
    public class BulletHelper : MonoBehaviour 
    {
        public void searchAndDestroy(GameObject gameObject, string sratchName, GameObject bullet, float damage)
        {
            if (gameObject.name == sratchName)
            {
                CarHelper carHelper = gameObject.GetComponent<CarHelper>();
                carHelper.healthHelper.setDamageAmount(damage);
                carHelper.healthHelper.getDamage();
            }
            destroyObject(bullet);
        }

        public void destroyObject(GameObject gameObject)
        {
            Destroy(gameObject);
        }

    }
}