using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finish : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter (Collider other)
    {
        GameObject.Find("player").SendMessage("Finnish");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
