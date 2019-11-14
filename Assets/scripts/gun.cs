using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GunType { Semi, Burst, Auto };



public class Gun : MonoBehaviour
{
    public LayerMask collisionmask;
    public float GunID;
    public GunType gunType;
    public float rpm;
    public float damage = 1;

    public Transform spawn;
    public Transform shellejectionpoint;
    public Rigidbody shell;
    private LineRenderer tracer;

    //system
    private float secondBetweenShots;
    private float nextPossibleShootTime;

    void Start()
    {
        secondBetweenShots = 60 / rpm;
        if (GetComponent<LineRenderer>())
        {
            tracer = GetComponent<LineRenderer>();
        }

    }
    public void Shoot()
    {

        if (CanShoot())
        {



            Ray ray = new Ray(spawn.position, spawn.forward);
            RaycastHit hit;

            float shotDistance = 100756756756;

            if (tracer)
            {
                StartCoroutine("RenderTracer", ray.direction * shotDistance);

            }


            Rigidbody newshell = Instantiate(shell, shellejectionpoint.position, Quaternion.identity) as Rigidbody;
            newshell.AddForce(shellejectionpoint.forward * Random.Range(150f, 200f) + spawn.forward * Random.Range(-10f, 10f));

            
            if (Physics.Raycast(ray, out hit, shotDistance, collisionmask))
            {
                Debug.Log("hitting");
                shotDistance = hit.distance;

                var entity = hit.collider.GetComponent<Entity>();
                if (entity != null)
                {
                    entity.TakeDamage(damage);
                }

                nextPossibleShootTime = Time.time + secondBetweenShots;






            }
        }
    }
    public void ShootContinuous()
    {
        if (gunType == GunType.Auto)
        {


            Shoot();


        }
    }
    private bool CanShoot()
    {
        bool canShoot = true;

        if (Time.time < nextPossibleShootTime)
        {
            canShoot = false;
        }
        return canShoot;



    }
    IEnumerator RenderTracer(Vector3 hitpoint)
    {
        tracer.enabled = true;
        tracer.SetPosition(0, spawn.position);
        tracer.SetPosition(1, spawn.position + hitpoint);

        yield return null;
        tracer.enabled = false;




    }

}













