using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : MonoBehaviour {

    GameObject player;
    Vector3 offset;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + offset;//將盾牌的位置維持在披薩旁邊
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Bullet"))//撞到子彈
        {
            if (PlayerController.instance.isShieldExist)
            {
                Destroy(other.gameObject);//擋下子彈
                PlayerController.instance.saucemode.Remove(SauceMode.pineapple);
                PlayerController.instance.isShieldExist = false;
                Destroy(gameObject);//盾牌消滅
            }
        }
    }
}
