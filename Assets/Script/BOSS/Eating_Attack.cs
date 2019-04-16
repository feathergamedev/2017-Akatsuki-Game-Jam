using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eating_Attack : MonoBehaviour {
    
    public float Move_Speed;
    public int state;
    // Use this for initialization
	void Start () {
        state = -1;
	}
	
	// Update is called once per frame
	void Update () {
        if (state == 0)
        {
            transform.position -= new Vector3(Move_Speed, 0f, 0f);

            if(transform.position.x <= -1.5f)
                state = 1;
        }
        else if (state == 1){
            transform.position -= new Vector3(0f, Move_Speed, 0f);

            if(transform.position.y <= -3.0f)
                state = 2;
        }
        else if (state == 2){
            transform.position += new Vector3(Move_Speed, 0f, 0f);

            if (transform.position.x >= 1.5f)
                state = 3;
        }
        else if (state == 3){
            transform.position += new Vector3(0f, Move_Speed, 0f);

            if(transform.position.y >= 3.0f)
                state = 4;
        }
        else if(state==4){
            transform.position -= new Vector3(Move_Speed, 0f, 0f);

			if (transform.position.x <= 0.0f)
				state = -1;
        }
        else{}
    }


    public void Go_Eating(){
        state = 0;
    }
}
