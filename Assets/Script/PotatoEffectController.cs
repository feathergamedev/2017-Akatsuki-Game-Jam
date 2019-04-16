using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotatoEffectController : BulletEffectController
{
    public Sprite[] sprite;//四張圖片做動畫
    int spriteNum;//目前在第幾張圖
    float changeSpriteTime, changeSpriteTimer;

    void Start()
    {
        lifeTimer = 0;
        lifeTime = 1;
        doDamage = false;
        damage = 5;

        spriteNum = 0;
        changeSpriteTime = 0.05f;
        changeSpriteTimer = 0;
    }

    void Update()
    {
        if (spriteNum < 3 && PublicFunction.Cool(ref changeSpriteTimer, changeSpriteTime))
            spriteNum++;

        GetComponent<SpriteRenderer>().sprite = sprite[spriteNum];

        if (spriteNum == 3)
        {
            isDead = PublicFunction.Cool(ref lifeTimer, lifeTime);
        }

        if (isDead)
            Destroy(gameObject);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (doDamage == false)
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
                }
                doDamage = true;
            }
        }
    }
}
