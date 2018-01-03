using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscClass : MonoBehaviour {

    public Rigidbody rb;

    private int Power;
    private float Weight;
    private int Turn, Fade;

    public static int DCPower;
    public static float DCWeight;
    public static int DCTurn, DCFade;

    private float _Speed, _Angle, _Turn, _Fade;

    public int BackhandForehand = 1;

    public GameObject Putter, MidRange, Driver, DiscEmpty;

    public static bool CanMove = false;

	void Start () {
        rb = GetComponent<Rigidbody>();

        //Starting Disc
        GameObject _Putter = Instantiate(Putter, transform.position, Quaternion.Euler(-90 + AngleScript.Pitch, 0, AngleScript.Tilt)) as GameObject;
        _Putter.transform.parent = transform;
    }

    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(1))
        {
            BackhandForehand = -1;
        }
        if (Input.GetMouseButtonDown(0))
        {
            BackhandForehand = 1;
        }

        if (!ThrowingScript.hasThrown && !CanMove)                                                          //Instaiate Disc Types
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))                                           
            {
                DestroyChildObjects();
                GameObject _Putter = Instantiate(Putter, transform.position, Quaternion.Euler(-90 + AngleScript.Pitch, 0, AngleScript.Tilt)) as GameObject;
                _Putter.transform.parent = transform;
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                DestroyChildObjects();
                GameObject _MidRange = Instantiate(MidRange, transform.position, Quaternion.Euler(-90 + AngleScript.Pitch, 0, AngleScript.Tilt)) as GameObject;
                _MidRange.transform.parent = transform;
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                DestroyChildObjects();
                GameObject _Driver = Instantiate(Driver, transform.position, Quaternion.Euler(-90 + AngleScript.Pitch, 0, AngleScript.Tilt)) as GameObject;
                _Driver.transform.parent = transform;                                                       
            }
        }
        //Fix This ----------------------------------------
        UpdateDiscInfo();

        _Angle = AngleScript.Tilt;                                                  //Set Angle

        if (AngleScript.SpeedSet)                                                   //Set Speed
        {
            _Speed = AngleScript.Speed;
        }

        if (ThrowingScript.hasThrown == true && CanMove)
        {
            var CurrentSpeed = transform.InverseTransformDirection(rb.velocity) / 7;
            
            if (CurrentSpeed.z >= Power + 1)                                          //Turn Logic
            {
                _Turn = BackhandForehand * (Turn * (CurrentSpeed.z - (Power)));
                if (_Turn == 0)
                {
                    _Turn = -_Angle;
                }
                rb.AddRelativeForce(new Vector3(_Turn, 0, 0));                
            }
            
            if (CurrentSpeed.z <= Power - 1)                                        //Fade Logic
            {
                _Fade = BackhandForehand * (-Fade * (Power - CurrentSpeed.z));
                rb.AddRelativeForce(new Vector3(_Fade, 0, 0));
            }
        }

    }

    void UpdateDiscInfo()                                                       //Get Disc Flight Info
    {
        Power = DCPower;
        rb.mass = DCWeight;
        Fade = DCFade;
        Turn = DCTurn;
   
    }

    public void DestroyChildObjects()                                                  //Destory All Child Objects
    {
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }
}
