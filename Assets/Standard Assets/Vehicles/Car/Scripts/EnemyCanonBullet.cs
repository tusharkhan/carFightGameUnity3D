using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car { 
    public class EnemyCanonBullet : MonoBehaviour
    {
        private Transform target;
        private float movementTime = 0;
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

            transform.position = Vector3.MoveTowards(transform.position, target.position, 15 * Time.deltaTime);
        }


        private void OnCollisionEnter(Collision collision)
        {

            bulletHelper.searchAndDestroy(collision.gameObject, "Car", gameObject, 10f);
        }
    }
}
