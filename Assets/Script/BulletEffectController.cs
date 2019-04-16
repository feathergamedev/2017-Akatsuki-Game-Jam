using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEffectController : MonoBehaviour {

    public float lifeTime, lifeTimer;//存活時間
    public bool isDead;//存活時間到了

    public bool doDamage;//是否造成爆炸傷害了(爆炸只會造成一次傷害)
    public float damage;
    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
