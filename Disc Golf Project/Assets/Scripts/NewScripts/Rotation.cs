using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour {

    public float Speed;

    private float X;

    public Transform Disc;

	void Update () {
		
        //is Null
        if (!Disc)
        {
            Disc = GameObject.FindGameObjectWithTag("Disc").transform;
        }

        if (!Throw.hasThrown)
        {
            X = Input.GetAxis("Horizontal");

            Vector3 Turn = new Vector3 (0, X * Speed, 0);
            transform.Rotate(Turn);
            Disc.transform.Rotate(Turn, Space.World);
        }

	}
}
