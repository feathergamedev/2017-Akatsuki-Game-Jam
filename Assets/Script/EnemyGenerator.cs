using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour {
    public static EnemyGenerator instance;

    float Time_f;
    public GameObject[] EnemyList;
    public GameObject Enemy_Bullet;

    public int Wave;
    public int[] Enemy_idx;
    public float[] Time_perWave;
    int idx;

    private void Awake()
    {
        instance = this;

    }

    // Use this for initialization
    void Start () {
        Wave = 0;
		GameObject newCha = Instantiate(EnemyList[Enemy_idx[Wave]], EnemyList[Enemy_idx[Wave]].transform.position, EnemyList[Enemy_idx[Wave]].transform.rotation);
        Wave++;
        Destroy(newCha, 3f);
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (GameManager.instance.state == GameStatus.遊戲中)
        {
            Time_f += Time.deltaTime;

            if (Time_f >= Time_perWave[Wave])
            {
                if(Enemy_idx[Wave]==11){
					Instantiate(EnemyList[Enemy_idx[4]], EnemyList[Enemy_idx[4]].transform.position, EnemyList[Enemy_idx[4]].transform.rotation);
					Instantiate(EnemyList[Enemy_idx[0]], EnemyList[Enemy_idx[0]].transform.position, EnemyList[Enemy_idx[0]].transform.rotation);
                    Wave++;
					Time_f = 0.0f;                    
                }
                else if(Enemy_idx[Wave]==12){
					Instantiate(EnemyList[Enemy_idx[5]], EnemyList[Enemy_idx[5]].transform.position, EnemyList[Enemy_idx[5]].transform.rotation);
					Instantiate(EnemyList[Enemy_idx[7]], EnemyList[Enemy_idx[7]].transform.position, EnemyList[Enemy_idx[7]].transform.rotation);
					Wave++;
					Time_f = 0.0f;

				}
                else
                {
                    Instantiate(EnemyList[Enemy_idx[Wave]], EnemyList[Enemy_idx[Wave]].transform.position, EnemyList[Enemy_idx[Wave]].transform.rotation);
                    Wave++;
                    Time_f = 0.0f;

                }
            }

            if (Wave == 15)
                UIManager.instance.Go_BOSS();
        }
	}
}
