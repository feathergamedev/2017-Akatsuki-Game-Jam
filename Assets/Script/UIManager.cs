using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {
    public static UIManager instance;

    public Text Pause_Msg;
    public GameObject GG_Page;
    public Text Score;
    public Text Text_ClkAmount;

    public Text Tomato, Mustard;

    private void Awake()
    {
        instance = this;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


        Tomato.text = "x" + PlayerController.instance.potatoEnergy;
		Mustard.text = "x" + PlayerController.instance.cheeseEnergy;

        Score.text = ""+(int)PlayerController.instance.score;
        Text_ClkAmount.text = "x" + GameManager.instance.Clock_Amount;

        if(Input.GetKeyDown(KeyCode.P)){
            if (GameManager.instance.state == GameStatus.遊戲中)
                Game_Pause();
            else if (GameManager.instance.state == GameStatus.暫停中)
                Game_Resume();
            else if (GameManager.instance.state == GameStatus.結束)
                Game_Over();
        }
	}

	public void Game_Start()
	{
		GameManager.instance.state = GameStatus.遊戲中;
        Invoke("Go_Play", 1.5f);
	}

    public void Game_Pause(){
        GameManager.instance.state = GameStatus.暫停中;
    }

	public void Game_Resume()
	{
		GameManager.instance.state = GameStatus.遊戲中;
		Pause_Msg.gameObject.SetActive(false);
    }

    public void Game_Over(){
        SceneManager.LoadScene("Score");
    }

    public void Replay(){
        Application.LoadLevel(Application.loadedLevel);
	}

    public void GoHome(){
        SceneManager.LoadScene("Main");
    }

    public void Go_Play(){
		SceneManager.LoadScene("Playing");
	}

    public void Go_BOSS(){
        CameraFade.FadeOut();
        SceneManager.LoadScene("BOSS");
    }
}
