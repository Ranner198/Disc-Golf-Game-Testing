using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasRungScript : MonoBehaviour {

    public GameObject DiscEmpty;

    public SpawnDisc SD;

    public GameObject Disc;

    public void Start()
    {
        SD = DiscEmpty.GetComponent<SpawnDisc>();
    }

    public void Update()
    {
        if (!Disc)
        {
            Disc = GameObject.FindGameObjectWithTag("Disc");
        }
    }

    public void OnTriggerEnter(Collider BasketTrigger)
    {
        if (BasketTrigger.gameObject.tag == "Disc")
        {           
            StartCoroutine(WaitAndSpawn());
        }
    }

    IEnumerator WaitAndSpawn()
    {
        yield return new WaitForSeconds(1);
        Destroy(Disc);
        RungScript.hasRung = true;
        yield return new WaitForSeconds(1);
        SD.DestoryAllDiscs();        
    }
}
