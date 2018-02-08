using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetCode : MonoBehaviour {

    public static bool isStopped = false;

    public GameObject Disc;

    public Transform[] Basket;

    void FixedUpdate()
    {
        if (isStopped)
        {
            transform.position = new Vector3(Disc.transform.position.x, Disc.transform.position.y, Disc.transform.position.z);

            transform.LookAt(Basket[HoleController.HoleNum]);

            isStopped = false;
        }
    }
}
