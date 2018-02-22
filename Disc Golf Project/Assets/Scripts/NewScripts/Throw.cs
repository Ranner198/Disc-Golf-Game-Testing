using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Throw : MonoBehaviour {

    public float Power;
    private Slider _PowerSlider;
    public Rigidbody rb;

    //Has Thrown or not
    public static bool hasThrown = false;
    public bool windUp = false;
    private bool isMaxed = true;
    public static bool stopPowerBuilder = false;
    public bool hasHitGroundYet;

    void Start () {
        _PowerSlider = GameObject.Find("Power").GetComponent<Slider>();
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        hasHitGroundYet = true;
	}
    
	void Update () {

        if (!hasThrown)
        {
            if (Input.GetKeyDown(KeyCode.Space) && windUp)
            {
                hasHitGroundYet = false;
                hasThrown = true;
                Power = _PowerSlider.value;
                ThrowDisc();
                _PowerSlider.value = 0.0f;
            }

            if (Input.GetKeyDown(KeyCode.Space) && !windUp)
            {
                _PowerSlider.value = 0;
                isMaxed = false;
                windUp = true;
            }

            if (windUp && !stopPowerBuilder)
            {
                BuildingPower();
            }
        }

        if (hasHitGroundYet == false)
        {
            var Tilt = (float)RotateDiscScript._Tilt / 15;
            rb.AddRelativeForce(Tilt, 0, 0);
            rb.AddForce(Wind.speedX/5, 0, Wind.speedZ/5);           
        }
    }

    void ThrowDisc()
    {
        RungScript.Score++;
        rb.isKinematic = false;
        rb.velocity = transform.forward * Power/3;
        windUp = false;
        stopPowerBuilder = true;
    }

    void BuildingPower()
    {      

        if (!isMaxed)
            _PowerSlider.value += 1 * Time.deltaTime * 60;

        if (isMaxed)
            _PowerSlider.value -= 1 * Time.deltaTime * 60;

        if (_PowerSlider.value >= _PowerSlider.maxValue)
        {
            isMaxed = true;           
        }
        else if (_PowerSlider.value == _PowerSlider.minValue)
        {
            windUp = false;
            _PowerSlider.value = 0;
        }       
    }

    void OnCollisionEnter(Collision collision)
    {
        hasHitGroundYet = true;
    }
}
