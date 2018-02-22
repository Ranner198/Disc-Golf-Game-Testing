using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ColorChangePowerScript : MonoBehaviour {

    public Slider _PowerSlider;

    public Image _Image;
	
	void Update () {
        _Image.color = Color.Lerp(Color.yellow, Color.red, _PowerSlider.value / 100);
    }
}
