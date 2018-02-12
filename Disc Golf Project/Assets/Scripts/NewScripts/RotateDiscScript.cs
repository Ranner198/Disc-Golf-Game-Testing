using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class RotateDiscScript : MonoBehaviour {

    public static int _Tilt, _Pitch;

    public GameObject DiscEmpty;

    public SpawnDisc SD;

    void Start()
    {
        SD = DiscEmpty.GetComponent<SpawnDisc>();
    }

    public void TiltChange(float Value)
    {
        _Tilt = Mathf.RoundToInt(Value);
        SD.UpdateRotation();
    }

    public void PitchChange(float Value)
    {
        _Pitch = Mathf.RoundToInt(Value);
        SD.UpdateRotation();
    }
}
