using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookAt : MonoBehaviour {

    

    public Transform DiscEmpty;

    private Quaternion Rotation;
    private Vector3 Distance;

    void Start()
    {
        Rotation = DiscEmpty.transform.rotation;
        //Distance = DiscEmpty.transform.position;
    }

    void Update () {

        var Angle = DiscEmpty.transform.localEulerAngles;

        transform.rotation = Quaternion.Euler(Angle.x, Angle.y, Rotation.z);


        
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
	}
}
