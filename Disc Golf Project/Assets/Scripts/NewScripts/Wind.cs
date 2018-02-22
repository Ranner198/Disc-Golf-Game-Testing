using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour {

    public static float speedX, speedZ;

	void Update () {

        if (Reset.newWind)
        {
            NewWind();
            Reset.newWind = false;
        }

	}

    void NewWind()
    {
        speedX = Random.Range(-1.0f, 1.0f);
        speedZ = Random.Range(-1.0f, 1.0f);
    }
}
