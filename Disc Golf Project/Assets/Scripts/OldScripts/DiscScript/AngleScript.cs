using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class AngleScript : MonoBehaviour {

    public static int Pitch, Tilt, Speed = 0;

    //PowerSlider Change Colors
    public Slider SpeedSlider;
    public Image Fill;
    public Color Max = Color.red;
    public Color Min = Color.yellow;
    public int Currentval;
    public int MaxVal = 1000;
    public bool Maxed = false;
    public bool CountUp = false;
    public static bool SpeedSet = false;


    public void Start()                                                    //Slider Component
    {
        SpeedSlider = GameObject.Find("Power").GetComponent<Slider>();
    }

    public void TiltChange(float Z)                                         //Tilt
    {
        Tilt = Mathf.RoundToInt(-Z);
    }

    public void PitchChange(float Y)                                        //Pitch
    {
        Pitch = Mathf.RoundToInt(Y);
    }

    public void Update()                                                    //Slider Fill && Speed Counter Logic
    {
              
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CountUp = !CountUp;

            if (!CountUp && Speed != 0)
            {
                SpeedSet = true;
            }

        }

        if (CountUp)
        {
            if (Speed <= 1000 && Maxed == false)
            {
                Speed += 4;
            }

            if (Speed >= 0 && Maxed == true)
            {
                Speed -= 4;
            }

            if (Speed > 1000)
            {
                Maxed = true;
            }

            if (Speed < 0)
            {
                Maxed = false;
                CountUp = false;
                Speed = 0;
            }      
        }

        SpeedSlider.value = Speed;
        Fill.color = Color.Lerp(Min, Max, SpeedSlider.value/1000);
    }

}
