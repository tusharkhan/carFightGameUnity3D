using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
    public class BulletHelper : MonoBehaviour 
    {

        public void searchAndDestroy(GameObject gameObject, string searchName, GameObject bullet, float damage)
        {
            CarHelper carHelper = gameObject.GetComponent<CarHelper>();

            if (carHelper != null)
            {
                carHelper.healthHelper.setDamageAmount(damage);
                carHelper.healthHelper.getDamage();
            }
            else return;
            destroyObject(bullet);
        }


        public void makeImpact(Collision collision, ParticleSystem impactPartical)
        {
            foreach(ContactPoint contactPoint in collision.contacts)
            {
                Quaternion rotation = Quaternion.FromToRotation(Vector3.up, contactPoint.normal);
                Vector3 position = contactPoint.point;
                Instantiate(impactPartical, position, rotation);
            }
        }

        public void destroyObject(GameObject gameObject)
        {
            Destroy(gameObject);
        }
    }
}