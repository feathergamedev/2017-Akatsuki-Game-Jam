using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class HamburgerController : MonoBehaviour
{
    public Eating_Attack Eat_Attack;
    public Sprite[] Anim;
     float Anim_Clock, Attack_Clock;
    int Anim_idx;
    public float Anim_Frequent, Attack_Frequent;
     bool canAttack, attackDone;

    public GameObject[] Weapons;
    int Attack_idx;

    public int MaxHP;
    public int HP;

    public GameObject Player;

    public Flowchart flowchart;

    public float Second_Clock, Second_Frequent;
    // Use this for initialization
    void Start()
    {
        HP = MaxHP;
    }
	// Update is called once per frame
	void FixedUpdate () {


        if (GameManager.instance.state == GameStatus.遊戲中)
        {
            if (flowchart.GetBooleanVariable("isTalking") == false)
            {
                Player.GetComponent<PlayerController>().enabled = true;

                this.gameObject.GetComponent<SpriteRenderer>().sprite = Anim[Anim_idx];
                Attack_Clock += Time.deltaTime;
				Second_Clock += Time.deltaTime;


                if(Second_Clock >= Second_Frequent){
                    Eat_Attack.Go_Eating();
                    Second_Clock = 0.0f;
                }

                if (Attack_Clock >= Attack_Frequent && Attack_Clock < Attack_Frequent * 2)
                {
                    Attack();
                }
                else if (Attack_Clock >= Attack_Frequent * 2)
                {
                    attackDone = false;
                    Attack_Clock = 0.0f;
                }
                else
                {
                    Anim_Clock += Time.deltaTime;

                    if (Anim_Clock >= Anim_Frequent)
                    {
                        if (Anim_idx == 0)
                            Anim_idx = 1;
                        else
                            Anim_idx = 0;

                        Anim_Clock = 0.0f;
                    }
                }
            }
        }
	}

    void Attack(){
		if (!attackDone)
		{
			Attack_idx = Random.Range(0,3);
			/*
			  if (Attack_idx == 2)
			  {
				  Eat_Attack.Go_Eating();
			  }
			  else
			  {
				  Instantiate(Weapons[Attack_idx], Weapons[Attack_idx].transform.position, Weapons[Attack_idx].transform.rotation);
			  }
  */

			Instantiate(Weapons[Attack_idx], Weapons[Attack_idx].transform.position, Weapons[Attack_idx].transform.rotation);

			attackDone = true;
		}


		Anim_Clock += Time.deltaTime;
		if(Attack_idx==2){
			if (Anim_Clock >= Anim_Frequent)
			{
				if (Anim_idx == 4)
					Anim_idx = 5;
				else
					Anim_idx = 4;

				Anim_Clock = 0.0f;
			}            
        }
        else{
			if (Anim_Clock >= Anim_Frequent)
			{
				if (Anim_idx == 2)
					Anim_idx = 3;
				else
					Anim_idx = 2;

				Anim_Clock = 0.0f;
			}            
        }


    }

	public void TakeDamage(float damage)//受傷
	{
        Debug.Log(damage);
		HP -= (int)damage;
        if (HP <= 0)
        {
            GameManager.instance.Score += 100;
            UIManager.instance.Game_Over();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }


}
