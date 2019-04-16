using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SauceSpawnPointManager : MonoBehaviour {

    public GameObject[] sauce;
    float spawnCoolTime, spawnCoolTimer;
	// Use this for initialization
	void Start () {
        spawnCoolTime = Random.Range(7,20);
	}
	
	// Update is called once per frame
	void Update () {
        if (GameManager.instance.state == GameStatus.遊戲中)
        {
            if (PublicFunction.Cool(ref spawnCoolTimer, spawnCoolTime))
                Instantiate(sauce[(int)Random.Range(0, sauce.Length )], transform.position, transform.rotation);
        }
    }

}
