using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : entity
{
    public override void Die()
    {
        health += 1000;
    }


}

