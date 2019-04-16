using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMouth : MonoBehaviour {

    public Sprite[] Anim;
    int Anim_idx;
    float damage;
    public float HP;
    float _count;
    float _shootCount;
    float _aniCount;
    public GameObject bullet;
	// Use this for initialization
	void Start () {
        HP = 80;
        damage = 1;
        _count = 0;
        _shootCount = 0;
        _aniCount = 0;    
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y >= 4.2f) MoveDown();
        else { MoveHorzontal(Time.deltaTime);
            if (_shootCount >= 0.8f)
            {
                Shoot();
                _shootCount -= 0.8f;
            }
            if (_aniCount >= 0.3f)
            {
                Anim_idx++;
                this.gameObject.GetComponent<SpriteRenderer>().sprite = Anim[Anim_idx%3];
                _aniCount -= 0.3f;
            }
        }
        _aniCount += Time.deltaTime;
        _shootCount += Time.deltaTime;
        
	}

    void MoveDown()
    {
        transform.position -= new Vector3(0, 1.5f * Time.deltaTime, 0);
    }

    void MoveHorzontal(float dt)
    {
        _count += dt;
        transform.position += new Vector3( 2.0f * Mathf.Cos(_count) * Time.deltaTime, -0.2f * Mathf.Sin(_count) * Time.deltaTime, 0);

    }
    void Shoot()
    {
        Instantiate(bullet, transform.position, transform.rotation);
    }
    public void TakeDamage(float damage)//受傷
    {
        HP -= damage;
        if (HP <= 0)
            Destroy(gameObject);
    }
}
