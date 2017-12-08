using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetCode : MonoBehaviour {

    public static bool isStopped = false;

    public GameObject Disc;

    public GameObject Basket;

    void FixedUpdate()
    {
        if (isStopped && ThrowingScript.hasThrown)
        {           
            transform.position = new Vector3(Disc.transform.position.x, Disc.transform.position.y + 1, Disc.transform.position.z);
            transform.position = new Vector3(transform.position.x + -ThrowingScript.vector.x * 2, 
                transform.position.y, 
                transform.position.z + -ThrowingScript.vector.z * 2);
            isStopped = false;
        }
    }
}
