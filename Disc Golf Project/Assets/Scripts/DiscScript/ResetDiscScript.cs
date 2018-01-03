using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetDiscScript : MonoBehaviour {

    public static float timer = 99;

    public Transform[] Basket;

    public static float Angle;

    void Update()
    {
        if (timer >= 0 && timer < 30)
        {
            timer -= Time.deltaTime;
        }

        var DiscPos = transform.position;

        var BasketPos = Basket[HoleController.HoleNum].transform.position;

        Vector3 Together = (DiscPos - BasketPos).normalized;

        Angle = Mathf.Atan2(Together.z, Together.x) * Mathf.Rad2Deg + 90;

        if (timer <= 0)
        {


            ResetCode.isStopped = true;
            ThrowingScript.hasThrown = false;
          
            Vector3 _Pos = transform.position;
            _Pos.y = Terrain.activeTerrain.SampleHeight(transform.position);
            transform.position = new Vector3(transform.position.x, _Pos.y + 1, transform.position.z);         
            timer = 99;   
        }
    }

    void OnCollisionEnter(Collision coll)
    {      
        if (coll.gameObject.tag == "Ground")
        {
            timer = 3;           

            AngleScript.Speed = 0;
            AngleScript.SpeedSet = false;

            DiscClass.CanMove = false;
        }

        if (coll.gameObject.tag == "Water")
        {         
            transform.position = ThrowingScript.lastLoc;

            AngleScript.Speed = 0;
            AngleScript.SpeedSet = false;

            DiscClass.CanMove = false;
        }

    }
}
