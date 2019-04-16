using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cucmber_Move : MonoBehaviour {

    public float Rotate_Range, Move_Range;
    float Time_f;

	// Use this for initialization
	void Start () {
		Destroy(this.gameObject, 10f);		
	}
	
	// Update is called once per frame
	void Update () {
        Time_f += Time.deltaTime;

        if (Time_f <= 0.5f)
            this.gameObject.transform.Rotate(new Vector3(0f, 0f, Rotate_Range));

        this.gameObject.transform.Translate(new Vector3(Move_Range/2, -Move_Range, 0f));
	}
}
