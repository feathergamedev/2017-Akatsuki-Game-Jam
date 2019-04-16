using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cross_Fries : MonoBehaviour {

    public float Move_Speed;

	// Use this for initialization
	void Start () {
        Destroy(this.gameObject, 10f);	
	}
	
	// Update is called once per frame
	void Update () {
        this.gameObject.transform.Translate(new Vector3(0f, -Move_Speed, 0f));
	}
}
