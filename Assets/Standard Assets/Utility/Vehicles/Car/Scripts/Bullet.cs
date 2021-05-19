using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
    public class Bullet : MonoBehaviour
    {
        public BulletHelper bulletHelper;
        public string bulletName;
        public ParticleSystem impactParticls;

        [SerializeField]private float enemyCarBullerDamage = 4f;
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
                bulletHelper.makeImpact(collision, impactParticls);

            }
            else if ( (hitGameObject.tag == "Enemy") )
            {
                bulletHelper.searchAndDestroy(
                    hitGameObject, 
                    hitGameObject.name, 
                    gameObject,
                    carBullerDamage);
                bulletHelper.makeImpact(collision, impactParticls);
            }
        }



        private void Start()
        {
            bulletHelper = new BulletHelper();
        }


        private void Update()
        {
            transform.Rotate( new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 90) );
            counter += Time.deltaTime;

            if (counter >= 7f)
            {
                bulletHelper.destroyObject(gameObject);
                return;
            }
        }
    }
}
