using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SausageController : MonoBehaviour {

    GameObject player;
    public GameObject bullet;
    Vector3 offset;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = player.transform.position + offset;//將小香腸的位置維持在披薩旁邊

        if (player.GetComponent<PlayerController>().isShoot)
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        bullet.GetComponent<BulletController>().saucemode = SauceMode.sausage;
        Instantiate(bullet,transform.position,transform.rotation);

        player.GetComponent<PlayerController>().sausageShootCount ++;//One Ok Bug
    }
}
