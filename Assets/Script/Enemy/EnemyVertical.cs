using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVertical : MonoBehaviour {
    public float damage;//攻擊傷害
    float HP;
    public float shootTime;
    float _count;
    public GameObject bullet;
    GameObject player;
    float p_x, p_y;
    float Spawn_Clock;
    public float Spawn_Delay;

    //chance
    public bool hasProp;
    public int max;
    public int chance;
    int num;
    public GameObject showPic;

    // Use this for initialization
    void Start () {
		bullet = EnemyGenerator.instance.Enemy_Bullet;

		player = GameObject.Find("Player");
        HP = 20;
        damage = 1;

        _count = 0;
        
        Invoke("shoot", shootTime);
    }
	
	// Update is called once per frame
	void Update () {
        Spawn_Clock += Time.deltaTime;

        if (Spawn_Clock >= Spawn_Delay)
            Move(Time.deltaTime);
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
        transform.position += new Vector3(0, -2.5f*Time.deltaTime);
    }

    void shoot()
    {
        GameObject newBullet = Instantiate(bullet, transform.position, transform.rotation);
        newBullet.GetComponent<BulletV>().p_x = player.transform.position.x;
        newBullet.GetComponent<BulletV>().p_y = player.transform.position.y;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        if (hasProp)
            {
                GetLuck();
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

