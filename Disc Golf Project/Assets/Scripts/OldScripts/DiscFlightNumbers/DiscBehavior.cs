using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class DiscBehavior : MonoBehaviour{
    public int DBPower;
    [Tooltip("Weights: Putter = 0.5f, MidRange = 0.325f, Driver = .175f.")]
    public float DBWeight, DBDrag;
    public int DBTurn, DBFade;

    public void Start()
    {
        DiscClass.DCPower = DBPower;
        DiscClass.DCWeight = DBWeight;
        DiscClass.DCTurn = DBTurn;
        DiscClass.DCFade = DBFade;
        DiscClass.DCDrag = DBDrag;
    }
}
