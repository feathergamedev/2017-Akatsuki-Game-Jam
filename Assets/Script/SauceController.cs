using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SauceController : MonoBehaviour {

    public float score;
    public SauceMode saucemode;
    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Move()
    {
        transform.Translate(Vector3.Normalize(-transform.up) * Time.deltaTime);
    }
}
