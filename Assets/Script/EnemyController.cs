using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
     
    public float damage;//攻擊傷害
    public float HP;

    float _count;
	// Use this for initialization
	void Start () {
        HP = 1;
        damage = 1;

        _count = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if(GameManager.instance.state == GameStatus.遊戲中)
         Move(Time.deltaTime);
       // shoot();
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
        transform.position += new Vector3(5 * Mathf.Cos(_count) * Time.deltaTime, -3*Mathf.Sin(_count)*Time.deltaTime, 0);
    }

    //void shoot()
    //{
    //    if (Input.GetButton("Fire") && canShoot == true)
    //    {
    //        Instantiate(bullet, transform.position + new Vector3(0f, Shoot_Pos, 0f), transform.rotation);
    //        shootCoolTimer = 0;
    //    }
    //    canShoot = PublicFunction.Cool(ref shootCoolTimer, shootCoolTime);
    //}

}
