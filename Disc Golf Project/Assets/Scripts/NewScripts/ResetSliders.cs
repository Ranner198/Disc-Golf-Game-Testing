using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ResetSliders : MonoBehaviour {

    public static bool resetRot = false;

    public Slider Tilt, Pitch;

	void Update () {

        if (resetRot)
        {
            resetRot = false;
            Tilt.value = 0;
            Pitch.value = 0;
        }
	}

    public void OnButtonClick()
    {
        resetRot = true;
    }
}
