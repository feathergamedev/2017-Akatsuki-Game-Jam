using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Enemy_Lip : MonoBehaviour
{

    public Sprite[] Anim;
    int Anim_idx;
    public float Anim_Frequent, Attack_Frequent, State_Frequent;
    float Anim_clock, Attack_clock, State_clock;
    public GameObject[] Attack;
    int Attack_idx;
    public float HP;
    Vector3 Target_Pos;
    bool isDone;
    // Use this for initialization
    void Start()
    {
        HP = (int)80;
        Attack_idx = 0;
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = Anim[Anim_idx];
        State_clock += Time.deltaTime;

        if(State_clock >= State_Frequent/2 && State_clock < State_Frequent && !isDone){
            Moving();

        }
        else if(State_clock >= State_Frequent){
            Attacking();
        }

    }

    void Moving(){
        Target_Pos = new Vector3(Random.Range(-2f, 2f), 4f, 0f);
        transform.DOMove(Target_Pos, State_Frequent/2);
        isDone = true;
    }

	public void TakeDamage(float damage)//受傷
	{
		HP -= damage;
		if (HP <= 0)
			Destroy(gameObject);

		GameSound.instance.Play_Shoot(GameSound.instance.EnemyDie);
	}


    void Attacking()
    {
        Attack_clock += Time.deltaTime;

        if (Attack_clock >= Attack_Frequent)
        {
            if (Attack_idx == 12)
                Attack_idx = 0;
            else
                Attack_idx++;

            switch (Attack_idx)
            {
                case 0:
                    Attack[0].SetActive(true);
                    Attack[1].SetActive(false);
                    Attack[2].SetActive(false);
                    Attack[3].SetActive(false);
					Anim_idx = 0;
					break;
                case 1:
                    Attack[0].SetActive(true);
                    Attack[1].SetActive(false);
                    Attack[2].SetActive(false);
                    Attack[3].SetActive(false);
                    Anim_idx = 0;
                    break;
				case 2:
					Attack[0].SetActive(true);
					Attack[1].SetActive(false);
					Attack[2].SetActive(false);
					Attack[3].SetActive(false);
                    Anim_idx = 0;
					break;
				case 3:
					Attack[0].SetActive(true);
					Attack[1].SetActive(false);
					Attack[2].SetActive(false);
					Attack[3].SetActive(false);
                    Anim_idx = 0;
					break;
				case 4:
					Attack[0].SetActive(true);
					Attack[1].SetActive(false);
					Attack[2].SetActive(false);
					Attack[3].SetActive(false);
                    Anim_idx = 0;
					break;
                case 5:
					Attack[0].SetActive(true);
					Attack[1].SetActive(false);
					Attack[2].SetActive(false);
					Attack[3].SetActive(false);
                    Anim_idx = 0;
					break;
                case 6:
                    Attack[0].SetActive(false);
                    Attack[1].SetActive(true);
                    Attack[2].SetActive(false);
                    Attack[3].SetActive(false);
                    Anim_idx = 1;
                    break;
                case 7:
                    Attack[0].SetActive(false);
                    Attack[1].SetActive(false);
                    Attack[2].SetActive(true);
                    Attack[3].SetActive(false);
                    GameSound.instance.Play_Shoot(GameSound.instance.MouthCannon);
                    Anim_idx = 1;
                    break;
                case 8:
                    Attack[0].SetActive(false);
                    Attack[1].SetActive(false);
                    Attack[2].SetActive(false);
                    Attack[3].SetActive(true);
                    Anim_idx = 2;
                    break;
				case 9:
					Attack[0].SetActive(false);
					Attack[1].SetActive(false);
					Attack[2].SetActive(false);
					Attack[3].SetActive(true);
					Anim_idx = 2;
					break;
                case 10:
                    Attack[0].SetActive(false);    
                    Attack[1].SetActive(false);
                    Attack[2].SetActive(false);
                    Attack[3].SetActive(true);
					Anim_idx = 2;
					break;
				case 11:
					Attack[0].SetActive(false);
					Attack[1].SetActive(false);
					Attack[2].SetActive(false);
					Attack[3].SetActive(true);
					Anim_idx = 2;
					break;
				case 12:
					Attack[0].SetActive(false);
					Attack[1].SetActive(false);
					Attack[2].SetActive(false);
					Attack[3].SetActive(false);
					Anim_idx = 0;
					isDone = false;
					State_clock = 0.0f;
					break;

			}

            Attack_clock = 0.0f;
        }

    }

    void Be_Ready(){
        Attack_idx = 0;
    }
}
