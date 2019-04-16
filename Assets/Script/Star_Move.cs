using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star_Move : MonoBehaviour {

    float Move_Speed;

	// Use this for initialization
	void Start () {
        Move_Speed = Random.Range(0.06f, 0.13f);	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(0f, -Move_Speed, 0f);
	}
}
