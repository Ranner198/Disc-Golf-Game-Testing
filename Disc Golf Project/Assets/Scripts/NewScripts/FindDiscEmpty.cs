using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindDiscEmpty : MonoBehaviour {

    public GameObject DE;	
	
	void LateUpdate () {
        var ROT = DE.transform.localEulerAngles;

        var POS = DE.transform.position;

        //transform.rotation = Quaternion.Euler(0, ROT.y, 0);

        transform.position = POS;
	}
}
