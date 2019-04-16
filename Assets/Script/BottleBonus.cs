using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleBonus : MonoBehaviour{

    public GameObject butter;
    float changeCoolTime, changeCoolTimer;
    float r, angle;
	// Use this for initialization
	void Start () {
        changeCoolTime = 0.15f;
        changeCoolTimer = 0;
        r = 2;
        angle = 0;
	}
	
	// Update is called once per frame
	void Update () {

        if(PublicFunction.Cool(ref changeCoolTimer,changeCoolTime))
            Instantiate(butter, transform.GetChild(0).position, transform.GetChild(0).rotation);

        angle+=2*Time.deltaTime;
        if (angle > 360)
            angle -= 360;

        if(gameObject.name.Contains("Cheese"))
            transform.position = new Vector3(transform.position.x + r * Mathf.Cos(angle) * Time.deltaTime,transform.position.y + r * Mathf.Sin(angle) * Time.deltaTime, 0);
        else if(gameObject.name.Contains("Tomato"))
            transform.position = new Vector3(transform.position.x + r * Mathf.Cos(angle+180) * Time.deltaTime, transform.position.y + r * Mathf.Sin(angle + 180) * Time.deltaTime, 0);
    }
}
