using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingScript : MonoBehaviour {

    public static bool hasThrown = false;

    public Rigidbody rb;

    //Where is the basket
    public GameObject Basket;
    public static Vector3 vector;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !hasThrown)
        {
            hasThrown = true;
            IsActive();
            Thrown();
        }

        if (!hasThrown)
            Rotation();

        //Stop Movement
        if (rb.velocity.magnitude < .01 && !hasThrown)
        {
            rb.isKinematic = true;
            vector = (Basket.transform.position - transform.transform.position).normalized;
        }
    }

    void Thrown()
    {        
        rb.AddRelativeForce(Vector3.forward * 5000);
    }

    void Rotation()
    {
        Quaternion Rotation = Quaternion.Euler(AngleScript.Pitch, 0, AngleScript.Tilt);
        transform.rotation = Quaternion.Slerp(transform.rotation, Rotation, Time.deltaTime * 100);
    }

    void IsActive()
    {
        if (hasThrown)
            rb.isKinematic = false;
        if (!hasThrown)
            rb.isKinematic = true;           
    }
}
