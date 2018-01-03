using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingScript : MonoBehaviour {

    public static bool hasThrown = false;

    public Rigidbody rb;

    public float Rot;

    public static Vector3 lastLoc;                                              //Incase O.B.

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {

        if (AngleScript.SpeedSet == true && !hasThrown)
        {
            lastLoc = transform.position;
            hasThrown = true;
            DiscClass.CanMove = true;
            IsActive();
            Thrown();            
        }

        if (!hasThrown)
        {
            Rotation();
        }

        //Stop Movement
        if (rb.velocity.magnitude < .01 && !hasThrown)
        {
            rb.isKinematic = true;           
        }
    }

    void Thrown()
    {        
        rb.AddRelativeForce(Vector3.forward * AngleScript.Speed * 3);
        HoleController.shotCount++;
        ResetDiscScript.timer = 15;
    }

    void Rotation()
    {       
        Quaternion Rotation = Quaternion.Euler(AngleScript.Pitch, RotateScript.totalRot, AngleScript.Tilt);
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
