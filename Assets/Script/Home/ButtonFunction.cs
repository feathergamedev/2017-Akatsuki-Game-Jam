using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonFunction : MonoBehaviour {

    public Image teach1, teach2;

    int curState = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (GameManager.instance.state == GameStatus.未開始)
		{
            if (Input.anyKeyDown)
            {
                if (curState == 0)
                {
                    teach1.gameObject.SetActive(true);
                    teach2.gameObject.SetActive(false);
                    curState = 1;
                }
                else if (curState == 1)
                {
                    teach1.gameObject.SetActive(false);
                    teach2.gameObject.SetActive(true);
                    curState = 2;

				}
                else if (curState == 2){
					teach1.gameObject.SetActive(false);
					teach2.gameObject.SetActive(false);
					curState = 99;
					Game_Start();
                    //Go_Play();
                }
                

			}
		}

        if (Input.GetKeyDown(KeyCode.G))
            Go_Boss();
	}

	public void Game_Start()
	{
		GameManager.instance.state = GameStatus.遊戲中;
		Invoke("Go_Play", 1.5f);
	}

	public void Go_Play()
	{
		GameManager.instance.state = GameStatus.遊戲中;

		SceneManager.LoadScene("Playing");
	}

    public void Go_Boss(){
		GameManager.instance.state = GameStatus.遊戲中;
		Invoke("Go_Play", 1.5f);
        SceneManager.LoadScene("BOSS");
    }
}
