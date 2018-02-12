using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glide : MonoBehaviour {

    public Rigidbody rb;
    public float gravity = 9.81f;
    public float Mass;

	void Update () {

        if (Throw.hasThrown)
        {
            float speed = rb.velocity.magnitude;
            gravity = 9.81f;
            float divided = gravity/speed;
            Vector3 _Gravity = new Vector3(0, -divided, 0);
            rb.AddForce(_Gravity);
        }
	}
}
