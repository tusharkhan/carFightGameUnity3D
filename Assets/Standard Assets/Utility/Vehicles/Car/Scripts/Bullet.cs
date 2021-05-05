using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
    public class Bullet : MonoBehaviour
    {
        public BulletHelper bulletHelper;
        public string bulletName;

        [SerializeField]private float enemyCarBullerDamage = 4f;
        [SerializeField]private float enemyCanonBullerDamage = 7f;

        [SerializeField]private float carCanonBullerDamage = 10f;
        [SerializeField]private float carBullerDamage = 7f;
        private float counter = 0;
        private void OnCollisionEnter(Collision collision)
        {
            GameObject hitGameObject = collision.gameObject;

            if ( (hitGameObject.name == "Car") )
            {
                bulletHelper.searchAndDestroy(
                        hitGameObject,
                        hitGameObject.name,
                        gameObject,
                        enemyCarBullerDamage );

            }
            else if ( (hitGameObject.tag == "Enemy") )
            {
                bulletHelper.searchAndDestroy(
                    hitGameObject, 
                    hitGameObject.name, 
                    gameObject,
                    carBullerDamage);
            }
        }



        private void Start()
        {
            bulletHelper = new BulletHelper();
        }


        private void Update()
        {
            counter += Time.deltaTime;

            if (counter >= 7f)
            {
                bulletHelper.destroyObject(gameObject);
                return;
            }
        }
    }
}
