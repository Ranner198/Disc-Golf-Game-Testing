using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateScript : MonoBehaviour {

    private float Horz;
    public float speed;

    public static float totalRot;

    void Update () {

        Horz = Input.GetAxis("Horizontal");

        float Rot = Horz * speed;

        transform.Rotate(new Vector3(0, Rot, 0));

        totalRot += Rot;

        if (ResetCode.isStopped)
        {
            totalRot = -ResetDiscScript.Angle;
        }
    }
}
