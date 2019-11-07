using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GunType { Semi, Burst, Auto };

public class gun : MonoBehaviour
{

    public GunType gunType;
    public float rpm;

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

            float shotDistance = 20;

            if (Physics.Raycast(ray, out hit, shotDistance))
            {
                shotDistance = hit.distance;

            }

            nextPossibleShootTime = Time.time + secondBetweenShots;

            if (tracer)
            {
                StartCoroutine("RenderTracer", ray.direction * shotDistance);

            }
            Rigidbody newshell = Instantiate(shell, shellejectionpoint.position, Quaternion.identity) as Rigidbody;
            newshell.AddForce(shellejectionpoint.forward * Random.Range(150f, 200f) + spawn.forward * Random.Range(-10f, 10f));  
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













