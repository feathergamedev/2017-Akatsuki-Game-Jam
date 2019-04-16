using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 番茄醬:直線發射打到後爆開
 芥末:攻擊高
 起司:直線發射打到後把附近敵人吸起來
*/

/*
功能性佐料(會發光，與純加分佐料做區別)：

鳳梨(pineapple)：防護罩，環繞在機身周圍，碰觸到子彈可以抵禦攻擊
青豆(green_bean)：普通子彈的間距之間
辣椒(chili)：子彈有火焰效果
香菇(mushrooms)：子彈很大顆但很慢
小香腸(sausage)：飛在披薩旁邊會幫忙持續發射子彈(攻擊力低)
 
*/

public class BulletController : MonoBehaviour
{

    public Sprite[] sprite;
    int spriteNum;
    float changeSpriteTime, changeSpriteTimer;
    public Sprite chiliBullet, mushroomBullet;//佐料輔助型子彈

    public SauceMode saucemode;//佐料模式    
    public Sprite normalBullet;//普通子彈

    public float lifeTime, lifeTimer;//存活時間
    public bool isDead;//子彈存活時間到了
    public float damage;//子彈傷害
    public BulletMode mode;//子彈模式

    public GameObject potatoEffect;//番茄醬爆炸特效
    public GameObject cheeseEffect;//起司黏住特效
    public float moveSpeed;//子彈飛行速度

    public float Fly_Range;


    void Start()
    {
        changeSpriteTime = 0.05f;
        changeSpriteTimer = 0;
        spriteNum = 0;

        lifeTimer = 0;
        lifeTime = 5;
        isDead = false;

        damage = 10f;

        if (saucemode == SauceMode.sausage || saucemode == SauceMode.greenBean)//小香腸、青豆攻擊力低
            damage = 5f;

        moveSpeed = 1;
    }

    void Update()
    {
        if (saucemode == SauceMode.chili)
        {
            if (spriteNum < 3 && PublicFunction.Cool(ref changeSpriteTimer, changeSpriteTime))
                spriteNum++;
            else if (spriteNum >= 3)
                spriteNum = 0;

            chiliBullet = sprite[spriteNum];//火焰彈
            GetComponent<SpriteRenderer>().sprite = chiliBullet;
        }

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
                case 21: // BOSS
                    other.GetComponent<HamburgerController>().TakeDamage(damage);
                    break;
                case 22: // TypeLip
                    other.GetComponent<Enemy_Lip>().TakeDamage(damage);
                    break;
                case 24: // TypeMouth
                    other.GetComponent<EnemyMouth>().TakeDamage(damage);
					break;
            }


            //			other.GetComponent<EnemyController>().TakeDamage(damage);
            switch (mode)
            {
                case (BulletMode.normal)://普通子彈
                    break;
                case (BulletMode.potato)://番茄醬子彈
                    Instantiate(potatoEffect, transform.position, transform.rotation);
                    Destroy(gameObject);
                    break;
                case (BulletMode.cheese)://起司子彈
                    Instantiate(cheeseEffect, transform.position, transform.rotation);
                    Destroy(gameObject);
                    break;
            }

            if (saucemode == SauceMode.greenBean)
            {//如果是青豆就造成低傷害
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
					case 21: // BOSS
						other.GetComponent<HamburgerController>().TakeDamage(damage);
						break;
					case 24: // TypeMouth
						other.GetComponent<EnemyMouth>().TakeDamage(damage);
						break;
                }
            }
        }
        //other.GetComponent<EnemyController>().TakeDamage(damage);
        Destroy(gameObject);
    }


    public void Move()
    {
        transform.Translate(new Vector3(0f, Fly_Range, 0f));
        //        transform.Translate(Vector3.Normalize(transform.up) * moveSpeed * Time.deltaTime*5);//往前飛
    }
}
