using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RungScript : MonoBehaviour {

    public static bool hasRung = false;

    public int holeNumber;

    public Transform[] teeBox;

    public BoxCollider[] BaksetTrigger;

    public GameObject DiscEmpty;

    public Transform[] lookDownTeePad;

    void Update () {

        if (hasRung == true)
        {        
            hasRung = false;

            holeNumber++;

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

    public void OnGUI()                                             //Finish hole message
    {
        GUI.Label(new Rect(10, 40, Screen.width, Screen.height), "Total Shots: " + HoleController.shotCount + "\n\nYour total score: " + HoleController.totalShots);

        if (hasRung)
        {
            /*
            int Temp = HoleController.shotCount;
            HoleController.shotCount = 0;
            GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, 500, 500), "You Rung It In: " + Temp);
            */
        }
    }
}
