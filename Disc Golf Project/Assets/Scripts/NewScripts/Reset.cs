using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour {

    public Rigidbody rb;

    public GameObject DiscEmpty;

    public SpawnDisc SD;


    //Locations
    public Transform DiscEmptyPos;
    public Vector3 LastSpot;
    public Vector3 NewSpot;

	void Start () {
        rb = GetComponent<Rigidbody>();
        DiscEmpty = GameObject.FindGameObjectWithTag("DiscEmpty");
        SD = DiscEmpty.GetComponent<SpawnDisc>();       
    }

	void Update () {

        if (!DiscEmptyPos)
            DiscEmptyPos = GameObject.FindGameObjectWithTag("DiscEmpty").transform;

        if (!Throw.hasThrown)
            LastSpot = transform.position;

        if (Throw.hasThrown)
        {
            
            if (rb.velocity.magnitude < .1)
            {
                Throw.hasThrown = false;
                NewSpot = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
                StartCoroutine(WaitAndMove());  
            }
        }
    }

    IEnumerator WaitAndMove() {

        yield return new WaitForSeconds(1.0f);

        DiscEmptyPos.transform.position = NewSpot;

        //Reset Throw
        Throw.hasThrown = false;
       
        //Destroy and Reset
        SD.DestoryAllDiscs();
    }
}
