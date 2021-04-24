using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
    public class Bullet : MonoBehaviour
    {
        public BulletHelper bulletHelper;
        private float counter = 0;
        private void OnCollisionEnter(Collision collision)
        {
            GameObject hitGameObject = collision.gameObject;

            if(hitGameObject.name == "Car")
                bulletHelper.searchAndDestroy(hitGameObject, hitGameObject.name, gameObject, 4f);
            else if(hitGameObject.tag == "enemy")
                bulletHelper.searchAndDestroy(hitGameObject, hitGameObject.name, gameObject, 6f);
            
        }



        private void Start()
        {
            bulletHelper = new BulletHelper();
        }


        private void Update()
        {
            counter += Time.deltaTime;

            if (counter >= 10f)
            {
                bulletHelper.destroyObject(gameObject);
                return;
            }
        }
    }
}
