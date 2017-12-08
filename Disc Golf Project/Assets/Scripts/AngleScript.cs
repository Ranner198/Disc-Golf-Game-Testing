using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class AngleScript : MonoBehaviour {

    public static int Pitch, Tilt;

    public void TiltChange(float Z)
    {
        Tilt = Mathf.RoundToInt(-Z);
    }

    public void PitchChange(float Y)
    {
        Pitch = Mathf.RoundToInt(Y);
    }
}
