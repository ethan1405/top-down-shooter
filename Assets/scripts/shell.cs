using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shell : MonoBehaviour
{

    private float lifeTime = 5;

    private Material mat;
    private Color originalCol;
    private float fadePercant;
    private float deathTime;
    private bool fading;

    void Start()
    {
        mat = GetComponent<Renderer>().material;
        originalCol = mat.color;
        deathTime = Time.time + lifeTime;

        StartCoroutine("Fade");
    }
    IEnumerator Fade()
    {
        while (true)
        {
            yield return new WaitForSeconds(.2f);
            if (fading)
            {
                fadePercant += Time.deltaTime;
                mat.color = Color.Lerp(originalCol, Color.clear, fadePercant);

                if (fadePercant >= 1)
                {
                    Destroy(gameObject);
                }
            }
            else
            {
                if (Time.time > deathTime)
                {
                    fading = true;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider c)
    {
        if (c.tag == "Ground")
        {
           GetComponent <Rigidbody>().Sleep();
        }
    }
}


