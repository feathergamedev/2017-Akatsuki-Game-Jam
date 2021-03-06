﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUp : MonoBehaviour {

    public float damage;//攻擊傷害
    float HP;
    public float shootTime;
    float _count;
//    public GameObject bullet;
    GameObject player;
    float p_x, p_y;
    float throughEdge;
    bool doOnce = true;

    float Spawn_Clock;
    public float Spawn_Delay;

    //chance
    public bool hasProp;
    public int max;
    public int chance;
    int num;
    public GameObject showPic;

    // Use this for initialization
    void Start()
    {

//        bullet = EnemyGenerator.instance.Enemy_Bullet;
        player = GameObject.Find("Player");
        HP = 20;
        damage = 1;
        throughEdge = 0;
        _count = 0;

//        Invoke("shoot", shootTime);
    }

    // Update is called once per frame
    void Update()
    {
        Spawn_Clock += Time.deltaTime;

        if (Spawn_Clock >= Spawn_Delay)
            Move(Time.deltaTime);

        if (transform.position.x > -1.3f && doOnce)
        {
            transform.Rotate( new Vector3(0, 0, 180));
            doOnce = false;
        }
    }

    public void TakeDamage(float damage)//受傷
    {
        HP -= damage;
        if (HP <= 0)
            Destroy(gameObject);
    }

    void Move(float dt)
    {
        _count += dt;
        transform.position += new Vector3(0.75f* Time.deltaTime, 6f * Mathf.Sin(_count / 0.5f) * Time.deltaTime, 0);
    }
/*
    void shoot()
    {
        GameObject newBullet = Instantiate(bullet, transform.position, transform.rotation);
        newBullet.GetComponent<BulletV>().p_x = player.transform.position.x;
        newBullet.GetComponent<BulletV>().p_y = player.transform.position.y;

    }
*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        throughEdge++;
        if (throughEdge > 2) {
            Destroy(gameObject);
            if (hasProp)
            {
                GetLuck();            
            }
        }
    }

    void GetLuck()
    {
        num = UnityEngine.Random.Range(0, max);
        if (num <= chance) DropProp();
    }

    void DropProp()
    {
        Instantiate(showPic, transform.position, transform.rotation);
    }

}