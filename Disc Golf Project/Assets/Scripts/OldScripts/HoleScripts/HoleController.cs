using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleController : MonoBehaviour {

    public static int HoleNum = 0;
    
    public static int shotCount;
    public static int totalShots;

    public GameObject DiscEmpty;

    public DiscClass DC;

    public Transform[] TeeBoxLocations;

    public Rigidbody rb;

    //Delete Later
    public float Timer = 99;

    private void Start()
    {
        rb.GetComponent<Rigidbody>();
    }

    void Update () {

        if (RungBasketScript.hasRung && Timer == 99)                                          //if the disc has Rung the basket
        {           
            Timer = 3;
        }
             
        if (Timer >= 0 && Timer < 30)
            Timer -= Time.deltaTime;

        if (Timer <= 0)
        {
            RungScript();           
        }
            
    
	}

    void RungScript()                                                          //has rung the basket function
    {

        

        if (HoleNum > TeeBoxLocations.Length)
        {
            HoleNum = 0;           
        }
        else
            HoleNum++;

        if (HoleNum > 18)                                                     //Loop if started on a hole other than #1 (For Later Use)
        {
            HoleNum = 1;
        }

        print(HoleNum);

        totalShots += shotCount;                                              //Add Shots and reset for next hole
        shotCount = 0;                                                      //Reseted in RungBasketScript

        ResetDiscScript.timer = 0;
       
        rb.isKinematic = true;

        DiscEmpty.transform.position = TeeBoxLocations[HoleNum].transform.position;     //transform player to next hole

        ResetCode.isStopped = true;
        ResetCode.isStopped = false;

        RungBasketScript.hasRung = false;    

        Timer = 99;
    }
}
