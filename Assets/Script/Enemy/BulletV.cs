using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletV : MonoBehaviour {
    public float speed;
    public float p_x, p_y;
    GameObject enemyV;
    Vector3 pos;
    // Use this for initialization
    void Start () {
        pos = new Vector3(transform.position.x,transform.position.y,0);
	}
	
	// Update is called once per frame
	void Update () {
        MoveDown();
       
	}

    void MoveDown()
    {
        transform.position += new Vector3(speed*(p_x-pos.x), speed*(p_y-pos.y) , 0) * Time.deltaTime;
    }
}
