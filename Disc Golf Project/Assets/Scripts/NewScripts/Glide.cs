using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glide : MonoBehaviour {

    public Rigidbody rb;

    public float Mass;


	void Update () {

        if (Throw.hasThrow)
        {
            //add if statement for 2 speeds
            if (rb.velocity.magnitude > 20)
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            else
                rb.velocity = new Vector3(rb.velocity.x, rb.velocity.magnitude - 32, rb.velocity.z);
        }

	}
}
