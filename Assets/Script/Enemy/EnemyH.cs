using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyH : MonoBehaviour {

    public float damage;//攻擊傷害
    float HP;

    float _count;
    public float speed;
    public float standbyNumL,standbyNumR;
    public float standbySpeed;
    float throughEdge;

    //chance
    public bool hasProp;
    public int max;
    public int chance;
    int num;
    public GameObject showPic;

    // Use this for initialization
    void Start()
    {
        HP = 30;
        damage = 1;

        _count = 0;
        throughEdge = 0;
    }

    // Update is called once per frame
    void Update()
    {
		
        if (transform.position.x <= standbyNumL || transform.position.x >= standbyNumR) {
            StandBy();
        }
        else  Move(Time.deltaTime);
    }

    public void TakeDamage(float damage)//受傷
    {
        HP -= damage;
        if (HP <= 0)
            Destroy(gameObject);

		GameSound.instance.Play_Shoot(GameSound.instance.EnemyDie);
    }

    void Move(float dt)
    {
        transform.position += new Vector3(speed* Time.deltaTime, 0, 0);
    }

    void StandBy()
    {
        transform.position += new Vector3(standbySpeed * Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        throughEdge++;
        if (throughEdge > 1)
        {
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