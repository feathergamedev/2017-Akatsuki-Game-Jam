using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunctionalSauce : SauceController
{

    GameObject player;

    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");

        //設定佐料分數
        if (saucemode == SauceMode.sauceBottle)
            score = 1;
        else if (saucemode == SauceMode.pineapple)
            score = 2;
        else if (saucemode == SauceMode.greenBean)
            score = 3;
        else if (saucemode == SauceMode.chili)
            score = 4;
        else if (saucemode == SauceMode.mushroom)
            score = 5;
        else if (saucemode == SauceMode.sausage)
            score = 6;
    }


    void Update()
    {
        Move();
        Move();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && other.gameObject.layer == LayerMask.NameToLayer("Player")) 
        {
            player.GetComponent<PlayerController>().ChangeSauceMode(saucemode);//改變玩家的佐料模式
            if (saucemode == SauceMode.sauceBottle)
            {
                if (this.gameObject.name.Contains("Cheese") && this.gameObject.tag == "Sauce")
                {
                    other.GetComponent<PlayerController>().cheeseEnergy += 1;//增加醬料
                }
                else if (this.gameObject.name.Contains("Tomato") && this.gameObject.tag == "Sauce")
                    other.GetComponent<PlayerController>().potatoEnergy += 1;
            }

            Destroy(gameObject);
        }
    }
}
