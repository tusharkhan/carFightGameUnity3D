using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car { 
    public class EnemyCanonBullet : MonoBehaviour
    {
        private Transform target;
        private float movementTime = 0;
        private float canonBulletDamage = 7f;
        private float carLayer = 11;

        public BulletHelper bulletHelper;

        // Start is called before the first frame update
        void Start()
        {
            bulletHelper = new BulletHelper();
            target = GameObject.Find("Target").transform;
        }

        // Update is called once per frame
        void Update()
        {
            movementTime += Time.deltaTime;

            if ( movementTime >= 10f)
            {
                bulletHelper.destroyObject(gameObject);
                return;
            } 

            transform.LookAt(target.position);

            transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * 15);
        }


        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.layer == carLayer)
                bulletHelper.searchAndDestroy(collision.gameObject, "Car", gameObject, canonBulletDamage);
        }
    }
}
