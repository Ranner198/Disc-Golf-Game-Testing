using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RungBasketScript : MonoBehaviour {

    public static  bool hasRung = false;

    public int HoleNumber;

    private float Timer = 0;

    public GameObject DiscEmpty;

    public SpawnDisc SD;

    public void Start()
    {
        SD = DiscEmpty.GetComponent<SpawnDisc>();
    }

    private void Update()
    {
        if (Timer >= 0)
        {
            Timer -= Time.deltaTime;
        }
    }

    private void OnTriggerStay(Collider coll)
    {
        
        if (coll.gameObject.tag == "Disc")
        {
            if (HoleController.HoleNum == HoleNumber)
            {
         
            }
            //Else Black Ace?
        }
    }

    public void OnGUI()                                             //Finish hole message
    {
        GUI.Label(new Rect(10, 40, Screen.width, Screen.height), "Total Shots: " + HoleController.shotCount + "\n\nYour total score: " + HoleController.totalShots);

        if (hasRung)
        {
            int Temp = HoleController.shotCount;
            HoleController.shotCount = 0;
            GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, 500, 500), "You Rung It In: " + Temp);
        }
    }
}

