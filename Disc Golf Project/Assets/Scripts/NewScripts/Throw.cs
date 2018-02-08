using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Throw : MonoBehaviour {

    public float Power;
    private Slider _PowerSlider;
    public Rigidbody rb;

    //Has Thrown or not
    public static bool hasThrow = false;
    public bool windUp = false;
    private bool isMaxed = false;

    void Start () {
        _PowerSlider = GameObject.Find("Power").GetComponent<Slider>();
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
	}

	void Update () {

        if (!hasThrow)
        {
            if (Input.GetKeyDown(KeyCode.Space) && windUp)
            {
                hasThrow = true;
                Power = _PowerSlider.value;
                ThrowDisc();
            }

            if (Input.GetKeyDown(KeyCode.Space) && !windUp)
            {
                _PowerSlider.value = 0;
                isMaxed = false;
                windUp = true;
            }

            if (windUp)
            {
                BuildingPower();
            }
        }
	}

    void ThrowDisc()
    {
        rb.isKinematic = false;
        rb.velocity = transform.forward * (Power/3);
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
        else if (_PowerSlider.value < _PowerSlider.minValue)
        {
            windUp = false;
            _PowerSlider.value = 0;
        }
    }
}
