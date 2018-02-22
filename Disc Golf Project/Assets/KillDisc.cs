using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillDisc : MonoBehaviour {

    public Terrain _Terrain;

    public GameObject Disc;

    private void Update()
    {
        if (!Disc)
        {
            Disc = GameObject.FindGameObjectWithTag("Disc");
        }
    }

    void OnCollisionEnter(Collision coll)
    {      
        if (coll.gameObject.tag == "Disc")
        {
            var X = Disc.transform.position.x;
            var Z = Disc.transform.position.z;

            Vector3 Where = new Vector3(X, 0, Z);

            var Height = _Terrain.SampleHeight(Where);

            Disc.transform.position = new Vector3(X, Height + 1, Z);


        }
    }
}
