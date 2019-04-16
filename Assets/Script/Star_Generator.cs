using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star_Generator : MonoBehaviour {

    public GameObject[] Star_List;
    int List_idx;
    Vector3 Target_Pos;
    float Time_f;
    public float Time_Frequent;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        Time_f += Time.deltaTime;
        if(Time_f >= Time_Frequent){
			Target_Pos = new Vector3(Random.Range(-2.43f, 2.43f), Random.Range(-5f, 5f), 0f);
            List_idx = Random.Range(0, 6);
            Instantiate(Star_List[List_idx], Target_Pos, transform.rotation);
            Time_f = 0.0f;
        }
	}
}
