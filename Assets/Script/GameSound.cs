using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSound : MonoBehaviour {
    public static GameSound instance;

    public AudioSource Shoot, MouthCannon, Hurt, GetItem, EnemyDie;

    // Use this for initialization

    private void Awake()
    {
        instance = this;
    }

    void Start () {
        DontDestroyOnLoad(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Play_Shoot(AudioSource sound){
        sound.Play();
    }

}
