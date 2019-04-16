using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Text_Blink : MonoBehaviour {

    public Image Notice;
    public Color[] color_list;

    float Time_f;
    int state;
    public float Time_Frequent;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Time_f += Time.deltaTime;

        if (Time_f >= Time_Frequent)
        {
			Notice.color = color_list[state];

			if(state==1){
                state = 0;
            }
            else{
                state = 1;
            }

            Time_f = 0.0f;
        }
	}
}
