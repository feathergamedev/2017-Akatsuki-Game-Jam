using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlowMotion : MonoBehaviour {

    public Camera cam;
    public GameObject bg;
    float Time_f;
    public float Clock_Limit;
    public bool isStart;

    public Color init, slowed;

	public AudioSource audio;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		audio.pitch = Time.timeScale;

        if (Input.GetKeyDown(KeyCode.T))
        {
            if (GameManager.instance.Clock_Amount != 0 && !isStart)
            {
                isStart = true;
                GameManager.instance.Clock_Amount--;
            }
        }

        if(isStart){
			PlayerController.instance.Move_Range = 0.045f;
			PlayerController.instance.shootCoolTime = 0.15f;            

            Time_f += Time.deltaTime;
            Time.timeScale = 0.3f;
            bg.GetComponent<RawImage>().color = slowed;
        }
        else
        {
            PlayerController.instance.Move_Range = 0.07f;
            PlayerController.instance.shootCoolTime = 0.2f;
            Time.timeScale = 1.0f;
			bg.GetComponent<RawImage>().color = init;
        }

        if (Time_f >= Clock_Limit)
        {
            isStart = false;
            Time_f = 0.0f;
        }

        Time.fixedDeltaTime = 0.02f * Time.timeScale;
    }

}
