using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLine : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        MoveDown();
	}

    void MoveDown()
    {
        transform.position += new Vector3(0, -2.5f) * Time.deltaTime;
    }
}
