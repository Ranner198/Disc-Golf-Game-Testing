using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Rotation : MonoBehaviour {

    public float Speed;

    private float X, Y;

    public Transform Disc;

    public SpawnDisc SD;

    public Slider Pitch;
    private float Angle;

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

            Y = Input.GetAxis("Vertical");

            if (Input.GetAxis("Vertical") != 0)
            {
                Angle += -(Y * Speed);
                Pitch.value = Angle;
            }

            if (Angle > Pitch.maxValue)
            {
                Angle = Pitch.maxValue;
            }
            if (Angle < Pitch.minValue)
            {
                Angle = Pitch.minValue;
            }
        }

	}
}
