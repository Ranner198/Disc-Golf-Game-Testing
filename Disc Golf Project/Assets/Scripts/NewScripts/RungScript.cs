using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class RungScript : MonoBehaviour {

    public static bool hasRung = false;

    public int holeNumber;

    public Transform[] teeBox;

    public GameObject[] BasketTarget;

    public Transform[] lookDownTeePad;

    public GameObject DiscEmpty;

    public static int Score, TotalScore;
    public float Distance;

    public Text _Score, _TotalScore, _Distance;

    void Update () {

        _Score.text = "Strokes: " + Score.ToString();
        _TotalScore.text = "Total Strokes: " + TotalScore.ToString();

        Distance = (DiscEmpty.transform.position - BasketTarget[holeNumber].transform.position).magnitude;

        _Distance.text = "Distance: " + Mathf.CeilToInt(Distance * 3.28f).ToString() + "\"";

        if (hasRung == true)
        {
            TotalScore += Score;
            Score = 0;

            hasRung = false;

            holeNumber++;

            ResetSliders.resetRot = true;

            Throw.stopPowerBuilder = false;

            if (holeNumber > teeBox.Length - 1)
            {
                holeNumber = 0;
                DiscEmpty.transform.position = teeBox[0].transform.position;
                DiscEmpty.transform.LookAt(lookDownTeePad[0]);
                Throw.hasThrown = false;               
            }
            else {
                DiscEmpty.transform.position = teeBox[holeNumber].transform.position;
                DiscEmpty.transform.LookAt(lookDownTeePad[holeNumber]);
            }
        }
	}
}
