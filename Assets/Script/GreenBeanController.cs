using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBeanController : BulletController
{


    // Use this for initialization
    void Start()
    {
        lifeTimer = 0;
        lifeTime = 5;
        isDead = false;
        moveSpeed = 1;

        damage = 0.5f;//青豆的子彈攻擊力低
    }

    // Update is called once per frame
    void Update()
    {
        isDead = PublicFunction.Cool(ref lifeTimer, lifeTime);
        if (isDead)
            Destroy(gameObject);

        Move();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            switch (other.gameObject.layer)
            {
                case 11: // Type A
                    other.GetComponent<EnemyH>().TakeDamage(damage);
                    break;
                case 12: // Type B
                    other.GetComponent<EnemyCircle>().TakeDamage(damage);
                    break;
                case 13: // Type C
                    other.GetComponent<EnemyVertical>().TakeDamage(damage);
                    break;
                case 14: // Type D
                    other.GetComponent<EnemyOneShot>().TakeDamage(damage);
                    break;
                case 15: // Type E
                    other.GetComponent<EnemyUp>().TakeDamage(damage);
                    break;
                case 16: // Type F
                    other.GetComponent<EnemyCircle>().TakeDamage(damage);
                    break;
                    Destroy(gameObject);
            }
        }
    }
}
