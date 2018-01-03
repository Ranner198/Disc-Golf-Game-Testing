using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscController : MonoBehaviour {
    
    public Rigidbody rb;   

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (rb.velocity.magnitude < .05)
        {
            //ResetCode.isStopped = true;
        }
    }
}
