using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GunType { Semi, Burst, Auto };
public class gun : MonoBehaviour
{

    public GunType gunType;

    public Transform spawn;

    public void Shoot()
    {
        Ray ray = new Ray(spawn.position, spawn.forward);
        RaycastHit hit;

        float shotDistance = 20;

        if (Physics.Raycast(ray, out hit, shotDistance))
        {
            shotDistance = hit.distance;

        }
        Debug.DrawRay(ray.origin, ray.direction * shotDistance, Color.red, 1);
    }

    public void ShootContinuous()
    {
        if (gunType == GunType.Auto){
            Shoot();
        }
       
    }
    public void Shootburst()
    {
        Debug.Log("Shoot burst");
        if(gunType == GunType.Burst)
        {
            Debug.Log("burst");
            for(int i=0; i<3; i++)
            {
                Shoot();
                Debug.Log("burst shot" + i);
            }            
        }        
    }

}
    

    

