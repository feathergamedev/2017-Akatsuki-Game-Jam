using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum GameStatus{
    未開始,遊戲中 ,暫停中,結束,
    GameStatus
}

public class GameManager : MonoBehaviour {
    public static GameManager instance;

    public int Clock_Amount;
    public ButtonFunction button;
    public GameStatus state = GameStatus.未開始;

//    public int GameStatus = 0; // 0:Initial 1:遊戲中 2:暫停中 3:遊戲結束
    public float Score;
    public float global_HP;
    private void Awake()
    {

        instance = this;
    }

    // Use this for initialization
    void Start () {
		DontDestroyOnLoad(this);
	}
	
	// Update is called once per frame
	void Update () {
        if (state == GameStatus.遊戲中){
            Score = PlayerController.instance.score;
            global_HP = PlayerController.instance.HP;
        }


			if(Input.GetKeyDown(KeyCode.Escape)){
            Application.Quit();
        }

        if (state == GameStatus.結束)
            Score = 0;
	}


}
