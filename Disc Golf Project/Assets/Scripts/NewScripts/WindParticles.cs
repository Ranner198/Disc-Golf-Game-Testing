using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class WindParticles : MonoBehaviour {

    public ParticleSystem PS;

    public Text WindSpeed;

    public Image Arrow;

	void Start () {
        PS = GetComponent<ParticleSystem>();
    }
	
	
	void Update () {

        Vector3 _MyPos = new Vector3(transform.position.x, 0, transform.position.y);

        float NormalizedVector = new Vector3(Wind.speedX, 0, Wind.speedZ).magnitude;

        float TanAngle = Mathf.Cos(NormalizedVector / Wind.speedZ) * Mathf.Rad2Deg;

        Vector3 myAngle = new Vector3(0, TanAngle, 0);

        Vector3 difference = (transform.position - myAngle);

        float differenceAngle = Vector3.Angle(difference, transform.forward);

        transform.rotation = Quaternion.Euler(0, TanAngle, 0);

        float Speed = new Vector3(Wind.speedX, 0, Wind.speedZ).magnitude;

        PS.startSpeed = Speed;

        WindSpeed.text = "Wind: " + Mathf.Abs(Wind.speedX + Wind.speedZ).ToString();

        Arrow.transform.rotation = Quaternion.Euler( 0, 0, TanAngle + 180);
    }
}
