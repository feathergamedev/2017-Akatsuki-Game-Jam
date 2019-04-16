using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusSauceController : SauceController //純加分佐料
{
	void Start () {

        //設定佐料分數
        if (saucemode == SauceMode.potato)
            score = 1;
        else if (saucemode == SauceMode.Shrimp)
            score = 2;
        else if (saucemode == SauceMode.greenpepper)
            score = 3;
	}
	
	void Update () {
        Move();
	}
}
