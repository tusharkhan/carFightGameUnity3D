using System.Collections;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
    public class CarGunHelper : MonoBehaviour
    {
        public float rotateSpeed = 4;
        public float bulletSpeed;
        public float canonBulletSpeed;
        public float timeIntervalBullet;
        public float timeIntervalCanonBullet;

        //make bullet instance
        public GameObject makeBullet(GameObject bullet, Transform spwonPoint)
        {
            return Instantiate(bullet, spwonPoint.position, spwonPoint.rotation);
        }


        //rotate object with mouse
        public void rotateWithMouseScroll(Transform objectToRotate)
        {
            objectToRotate.Rotate((Input.mouseScrollDelta.y * rotateSpeed* Time.deltaTime), 0, 0, Space.World);
        }

        //rotate towords target
        public void rotate(Transform objectToRotate, Transform target, bool yAxis = true)
        {
            // Determine which direction to rotate towards
            Vector3 targetDirection = target.position - objectToRotate.position;

            // The step size is equal to speed times frame time.
            float singleStep = rotateSpeed * Time.deltaTime;

            // Rotate the forward vector towards the target direction by one step
            Vector3 newDirection = Vector3.RotateTowards(objectToRotate.forward, targetDirection, singleStep, 0.0f);

            // Draw a ray pointing at our target in
            //Debug.DrawRay(objectToRotate.position, newDirection, Color.red);
            // Calculate a rotation a step closer to the target and applies rotation to this object
            if( yAxis ) objectToRotate.rotation = Quaternion.LookRotation(newDirection);
            else objectToRotate.rotation = Quaternion.LookRotation(new Vector3(newDirection.x, 0f, newDirection.z));
        }


        //move bullet to target
        public void moveBullet(GameObject bullet, Transform spwonPoint)
        {
            GameObject bulletObject = makeBullet(bullet, spwonPoint);
            Rigidbody bulletObjectRigid = bulletObject.GetComponent<Rigidbody>();
            bulletObjectRigid.velocity = bulletObject.transform.TransformDirection(Vector3.forward * bulletSpeed);
            bulletObject.transform.rotation = Quaternion.Euler(new Vector3(90f, 0, 0));
        }



        public void moveCanonBullet(GameObject gameObject, Transform target)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, target.position,  Time.time);
        }
    }
}