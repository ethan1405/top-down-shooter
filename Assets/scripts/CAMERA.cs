using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAMERA  : MonoBehaviour { 

    private Vector3 cameratarget;

    private Transform target;


    // Start is called before the first frame update
    void Start(){
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        cameratarget = new Vector3 (target.position.x, transform.position.y,target.position.z);
        transform.position = Vector3.Lerp(transform.position, cameratarget,Time.deltaTime * 8);
    }
}
