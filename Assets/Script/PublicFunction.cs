using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//YOYOYOYs
public enum BulletMode
{
    normal,
    potato,
    wasabi,
    cheese
}

public enum SauceMode
{
    nothing,
    potato,
    Shrimp,//蝦仁
    greenpepper,//青椒

    sauceBottle,//醬料瓶
    pineapple,//鳳梨
    greenBean,//青豆
    chili,//辣椒
    mushroom,//香菇
    sausage//小香腸
}

public static class PublicFunction {

    static public bool Cool(ref float timer,float coolTime)//冷卻
    {
        if (timer < coolTime)
        {
            timer += Time.deltaTime;
            return false;
        }
        else
        {
            timer = 0;
            return true;
        }
    }
}
