using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
    public class BulletHelper : MonoBehaviour 
    {
        public void searchAndDestroy(GameObject gameObject, string searchName, GameObject bullet, float damage)
        {
            if (gameObject.name == searchName)
            {
                CarHelper carHelper = gameObject.GetComponent<CarHelper>();

                if (carHelper != null)
                {
                    carHelper.healthHelper.setDamageAmount(damage);
                    carHelper.healthHelper.getDamage();
                }
                else return;
            }
            destroyObject(bullet);
        }

        public void destroyObject(GameObject gameObject)
        {
            Destroy(gameObject);
        }
    }
}