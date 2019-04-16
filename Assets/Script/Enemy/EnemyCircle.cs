using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyCircle : MonoBehaviour
{
    public Sprite[] Anim;
    int Anim_idx;
    float _aniCount;
    public float damage;//攻擊傷害
    float HP;

    float _count;
    public int dir;
    float throughEdge;
    public bool isFromLeft;

    float Spawn_Clock;
    public float Spawn_Delay;

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

        throughEdge = 0;
        _count = 0;
        _aniCount = 0;

        if (isFromLeft)
        {
            this.gameObject.transform.DORotate(new Vector3(0f, 0f, 116.27f), 1.7f).SetEase(Ease.InOutCirc);
            dir = 1;
        }
        else
        {
            this.gameObject.transform.DORotate(new Vector3(0f, 0f, -108.56f), 1.7f).SetEase(Ease.InOutCirc);
            dir = -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Spawn_Clock += Time.deltaTime;

        if (Spawn_Clock >= Spawn_Delay)
            Move(Time.deltaTime);

        _aniCount += Time.deltaTime;

        if (this.gameObject.layer != LayerMask.NameToLayer("TypeB"))
        {
            if (_aniCount >= 0.3f)
            {
                Anim_idx++;
                this.gameObject.GetComponent<SpriteRenderer>().sprite = Anim[Anim_idx % 2];
                _aniCount -= 0.3f;
            }
        }
    
    

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
        transform.position += new Vector3(dir*5.5f * Mathf.Cos(_count) * Time.deltaTime, -2.5f * Mathf.Sin(_count) * Time.deltaTime, 0);
    
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