using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDisc : MonoBehaviour {

    public GameObject[] _Disc;
    private int DiscSelection = 0;

    //Get Direction
    private Vector3 forward;

    void Start () {
        DestoryAllDiscs();
	}

	void Update () {

        forward = new Vector3 (0, transform.eulerAngles.y, 0);

        if (!Throw.hasThrown)
        {
            //Scroll Wheel Disc Selection
            if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                DiscSelection++;

                if (DiscSelection > _Disc.Length - 1)
                {
                    DiscSelection = 0;
                }

                DestoryAllDiscs();
            }
            if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                DiscSelection--;

                if (DiscSelection < 0)
                {
                    DiscSelection = _Disc.Length - 1;
                }

                DestoryAllDiscs();
            }

            if (Input.GetKey(KeyCode.Alpha1))
            {
                DiscSelection = 0;
                DestoryAllDiscs();
            }
            else if (Input.GetKey(KeyCode.Alpha2))
            {
                DiscSelection = 1;
                DestoryAllDiscs();
            }
            else if (Input.GetKey(KeyCode.Alpha3))
            {
                DiscSelection = 2;
                DestoryAllDiscs();
            }
        }
    }

    public void DestoryAllDiscs()
    {
        GameObject[] discsInScene = GameObject.FindGameObjectsWithTag("Disc");
        for (int i = 0; i < discsInScene.Length; i++)
        {
            Destroy(discsInScene[i]);
        }
        SpawnNewDisc();
    }

    void SpawnNewDisc()
    {
        GameObject Disc = Instantiate(_Disc[DiscSelection], transform.position, transform.rotation);
        Disc.transform.rotation = transform.rotation;
    }

    public void UpdateRotation()
    {
        GameObject Disc = GameObject.FindGameObjectWithTag("Disc");
        transform.rotation = Quaternion.Euler(RotateDiscScript._Pitch, forward.y, -RotateDiscScript._Tilt);
        Disc.transform.rotation = transform.rotation;
    }
}
