using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
                 
public class Show_Hp : MonoBehaviour {

    public HamburgerController BOSS;
    public Image BOSS_HP;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        BOSS_HP.fillAmount = (float)BOSS.HP / BOSS.MaxHP;
	}
}
