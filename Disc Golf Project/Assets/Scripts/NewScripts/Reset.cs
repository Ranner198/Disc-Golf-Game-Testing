using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour {

    public Rigidbody rb;

    public GameObject DiscEmpty;

    public SpawnDisc SD;

    public bool isSafe = true;

    //NewWind
    public static bool newWind = true;

    //Locations
    public Transform DiscEmptyPos;
    public Vector3 LastSpot;
    public Vector3 NewSpot;

	void Start () {
        rb = GetComponent<Rigidbody>();
        DiscEmpty = GameObject.FindGameObjectWithTag("DiscEmpty");
        SD = DiscEmpty.GetComponent<SpawnDisc>();
        ResetLoc();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Water")
        {
            isSafe = false;
            StartCoroutine(ResetToSafe());
        }
    }

    void LateUpdate () {

        if (!DiscEmptyPos)
            DiscEmptyPos = GameObject.FindGameObjectWithTag("DiscEmpty").transform;

        if (Throw.hasThrown)
        {
            
            if (rb.velocity.magnitude < .08)
            {
                Throw.hasThrown = false;
                NewSpot = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);

                if (isSafe == true)
                    StartCoroutine(WaitAndMove());
            }
        }
    }

    IEnumerator WaitAndMove() {

        yield return new WaitForSeconds(1.0f);

        newWind = true;

        DiscEmptyPos.transform.position = NewSpot;

        //Reset Throw
        Throw.hasThrown = false;

        //Destroy and Reset
        SD.DestoryAllDiscs();

        ResetLoc();

        ResetSliders.resetRot = true;

        Throw.stopPowerBuilder = false;
    }

    IEnumerator ResetToSafe()
    {

        yield return new WaitForSeconds(0.5f);

        newWind = true;

        DiscEmptyPos.transform.position = LastSpot;

        //Reset Throw
        Throw.hasThrown = false;

        //Destroy and Reset
        SD.DestoryAllDiscs();

        RungScript.Score += 1;

        isSafe = true;

        ResetLoc();

        Throw.stopPowerBuilder = false;
    }

    void ResetLoc()
    {
        LastSpot = DiscEmpty.transform.position;
    }
}
