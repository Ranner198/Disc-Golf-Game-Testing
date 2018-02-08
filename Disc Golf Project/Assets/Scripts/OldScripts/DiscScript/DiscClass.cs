using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscClass : MonoBehaviour {

    public Rigidbody rb;

    private int Power;
    private float Weight;
    private int Turn, Fade;

    public static int DCPower;
    public static float DCWeight, DCDrag;
    public static int DCTurn, DCFade;

    private float _Speed, _Angle, _Turn, _Fade, _Drag;                                                                 //Zero out on chain hit

    public static int BackhandForehand = 1;

    public GameObject Putter, MidRange, Driver, DiscEmpty;

    public static bool CanMove = false;

    void Start () {
        rb = GetComponent<Rigidbody>();

        Quaternion SpawnRot = Quaternion.Euler(AngleScript.Pitch + -90, 0, AngleScript.Tilt);

        //Starting Disc
        GameObject _Putter = Instantiate(Putter, transform.position, SpawnRot) as GameObject;
        _Putter.transform.parent = transform;
    }

    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(1))                                                                    //Forhand/Backhand Control
        {
            BackhandForehand = -1;
        }
        if (Input.GetMouseButtonDown(0))
        {
            BackhandForehand = 1;
        }

        Quaternion SpawnRot = Quaternion.Euler(AngleScript.Pitch + -90, 0, AngleScript.Tilt);

        if (!ThrowingScript.hasThrown && !CanMove)                                                          //Instaiate Disc Types
        {         
            if (Input.GetKeyDown(KeyCode.Alpha1))                                           
            {
                DestroyChildObjects();
                GameObject _Putter = Instantiate(Putter, transform.position, SpawnRot) as GameObject;
                _Putter.transform.parent = transform;
                //_Putter.transform.rotation = (SpawnRot);                
            }           
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                DestroyChildObjects();
                GameObject _MidRange = Instantiate(MidRange, transform.position, SpawnRot) as GameObject;
                _MidRange.transform.parent = transform;
                //_MidRange.transform.rotation = (SpawnRot);
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                DestroyChildObjects();
                GameObject _Driver = Instantiate(Driver, transform.position, SpawnRot) as GameObject;
                _Driver.transform.parent = transform;
                //_Driver.transform.rotation = (SpawnRot);
            }

            
        }

        var CurrentSpeed = transform.InverseTransformDirection(rb.velocity/4);    //Current Disc Speed


        var _Weight = Weight / ((CurrentSpeed.z / 20) + 1);                        //Glide Affect
     
        rb.mass = _Weight;

        rb.AddForce(Physics.gravity * rb.mass * .5f);

        rb.drag = _Drag;

        _Angle = AngleScript.Tilt;                                                  //Set Angle

        if (AngleScript.SpeedSet)                                                   //Set Speed
        {
            _Speed = AngleScript.Speed;
        }

        UpdateDiscInfo();                                                           //Update Disc Info

        if (ThrowingScript.hasThrown == true && CanMove)
        {           
            if (CurrentSpeed.z >= Power + 1)                                          //Turn Logic
            {
                _Turn = BackhandForehand * (Turn * (CurrentSpeed.z - (Power)));
                if (_Turn == 0)
                {
                    //_Turn = -_Angle;
                }
                rb.AddRelativeForce(new Vector3(_Turn, 0, 0));                
            }
            
            if (CurrentSpeed.z <= Power)                                        //Fade Logic
            {
                if (CurrentSpeed.x >= -4.5)
                {
                    _Fade = (BackhandForehand * -Fade) / 2;
                    rb.AddRelativeForce(new Vector3(_Fade, 0, 0));
                    //print("Fade: " + _Fade);
                }
            }
            
        }
        
        //print("Turn: " + _Turn);
        

    }

    void UpdateDiscInfo()                                                       //Get Disc Flight Info
    {
        Power = DCPower;
        Weight = DCWeight;
        Fade = DCFade;
        Turn = DCTurn;
        _Drag = DCDrag;
    }

    public void DestroyChildObjects()                                                  //Destory All Child Objects
    {
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }
}
