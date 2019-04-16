using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowTitle : MonoBehaviour {

    public GameObject[] Show_List;
    int List_idx;
    float Time_f;
    public float Show_Rate;


	// Use this for initialization
	void Start () {
        Destroy(this.gameObject, 5f);
	}
	
	// Update is called once per frame
	void Update () {
		Time_f += Time.deltaTime;

		if (List_idx <= 3)
		{
			if (Time_f >= Show_Rate)
			{
				Instantiate(Show_List[List_idx], Show_List[List_idx].transform.position, Show_List[List_idx].transform.rotation);
				List_idx++;
				Time_f = 0.0f;
			}
		}		
	}
}
