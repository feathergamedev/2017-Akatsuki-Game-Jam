using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
基礎分數(打敗敵人) 佐料分數
Move 移動
shoot 攻擊
GetScore 得分
TakeDamage 損傷
*/

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    bool invincible;
    float invincibleTime, invincibleTimer;

    public List<SauceMode> saucemode;
    GameObject player;//玩家物件
    public GameObject bullet;//子彈

    float horizontal, vertical;//水平、垂直移動
    public float score;//分數
    public float HP;//血量
    public float potatoEnergy;//番茄醬料量(子彈量)
    public float cheeseEnergy;//起司醬料量(子彈量)

    bool canShoot;//是否可以射擊
    float shootCoolTimer;
    public float shootCoolTime;

    public ParticleSystem hurted_particle;
    public Sprite[] Normal, Second, Third;
    float Anim_Clock;
    public float Anim_Frequent;
    public int Anim_idx;

    public GameObject greenBeanBullet, sausageBullet;//佐料子彈效果
    public GameObject shield;//防護罩
    public bool isShieldExist;//防護罩是否存在
    public bool isSausageExist;//佐料 小香腸
    public bool isShoot;//傳遞給小香腸 決定是否要發射
    public int sausageShootCount;//計算兩邊小香腸是否都發射

    public Sprite normalBullet;//普通子彈圖形
    Vector3 bulletScale;//子彈原本大小

    public float Move_Range;

    public Color Yellow, Red, Orange;

    Vector3[] Plating_Pos= new Vector3[8];
    int Plating_idx;

    public GameObject[] Sauce_List;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        Sauce_List = new GameObject[8];

        for (int i = 0; i < 8; i++)
            Sauce_List[i] = this.gameObject.transform.GetChild(i).gameObject; 

        invincible = false;
        invincibleTime = 2;
        invincibleTimer = 0;

//        Vector3[] Plating_Pos 
        player = GameObject.FindGameObjectWithTag("Player");
        score = 0;
        HP = 3;
        Anim_idx = 0;

        potatoEnergy = 0;
        cheeseEnergy = 0;

        canShoot = true;
        shootCoolTimer = 0; 
        shootCoolTime = 0.2f;

        isShieldExist = false;
        isSausageExist = false;
        isShoot = false;

        saucemode.Clear();

        bulletScale = new Vector3(1,1,1);
        bullet.transform.localScale = bulletScale;
        //bullet.GetComponent<SpriteRenderer>().sprite = normalBullet;

        Plating_Pos[0] = new Vector3(-0.54f, -0.22f, 0.0f);
		Plating_Pos[1] = new Vector3(0.31f, -0.8f, 0.0f);
		Plating_Pos[2] = new Vector3(-0.44f, -0.71f, 0.0f);
		Plating_Pos[3] = new Vector3(0.04f, -0.45f, 0.0f);
		Plating_Pos[4] = new Vector3(-0.05f, 0.25f, 0.0f);
		Plating_Pos[5] = new Vector3(0.01f, 0.68f, 0.0f);
		Plating_Pos[6] = new Vector3(0.63f, -0.62f, 0.0f);
		Plating_Pos[7] = new Vector3(0.33f, 0.02f, 0.0f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameManager.instance.state == GameStatus.遊戲中)
        {
            if(invincible == true)
                invincible = !(PublicFunction.Cool(ref invincibleTimer, invincibleTime));//無敵兩秒

            if (Input.GetKeyDown(KeyCode.H))
            {
                TakeDamage(1.0f);
            }

            Anim_Clock += Time.deltaTime;

            Move();
            Shoot();
            Anim();

            foreach (SauceMode s in saucemode)
                SauceAbility(s);

        }
        if ((int)HP == 0)
        {
            GameManager.instance.state = GameStatus.結束;
            UIManager.instance.Game_Over();
        }

    }

    void OnTriggerEnter2D(Collider2D other)//碰撞偵測
    {
        if (other.gameObject.tag == "Sauce")//吃到佐料
        {
            GetScore(other.GetComponent<SauceController>().score);//加分

            GameSound.instance.Play_Shoot(GameSound.instance.GetItem);

            foreach(GameObject Sauce in Sauce_List){
                if(other.name.Contains(Sauce.name))
                {
                    Sauce.SetActive(true);
                    Destroy(other.gameObject);
                }
            }

            /*if (Plating_idx < 7)
            {
                if (other.gameObject.layer == 19)
                { // Sauce
                    other.gameObject.GetComponent<FunctionalSauce>().enabled = false;
                    other.gameObject.transform.SetParent(this.gameObject.transform);
                    other.gameObject.transform.localPosition = Plating_Pos[Plating_idx];
                    Plating_idx++;
                }
                else if (other.gameObject.layer == 20)
                { // BonusSauce
                    other.gameObject.GetComponent<BonusSauceController>().enabled = false;
                    other.gameObject.transform.SetParent(this.gameObject.transform);
                    other.gameObject.transform.localPosition = Plating_Pos[Plating_idx];
                    Plating_idx++;
                }
            }*/
        }

        else if (other.gameObject.tag == "Enemy")//撞到敵人
        {
            TakeDamage(1.0f);
            GameSound.instance.Play_Shoot(GameSound.instance.Hurt);
        }
    }

    void Move()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");

        if (horizontal > 0)
            player.transform.Translate(new Vector3(Move_Range, 0f, 0f));
        //        player.transform.Translate(Vector3.Normalize(player.transform.right) * horizontal * Time.deltaTime * 5);
        else if (horizontal < 0)
            player.transform.Translate(new Vector3(-Move_Range, 0f, 0f));
        //          player.transform.Translate(Vector3.Normalize(player.transform.right) * horizontal * Time.deltaTime * 5);

        if (vertical > 0)
            player.transform.Translate(new Vector3(0f, Move_Range, 0f));
        //            player.transform.Translate(Vector3.Normalize(player.transform.up) * vertical * Time.deltaTime * 5);
        else if (vertical < 0)
            player.transform.Translate(new Vector3(0f, -Move_Range, 0f));
        //            player.transform.Translate(Vector3.Normalize(player.transform.up) * vertical * Time.deltaTime * 5);
    }

    void Shoot()
    {
        if (canShoot == true)//可以射擊
        {
            Vector3 newPos = new Vector3(transform.position.x, transform.position.y + 0.7f, 0f);

            if (Input.GetButton("Fire1"))//基本模式
            {
                GameSound.instance.Play_Shoot(GameSound.instance.Shoot);
                isShoot = true;//傳遞給小香腸 可射出
                GameObject newBul = Instantiate(bullet, newPos, transform.rotation);
                newBul.GetComponent<SpriteRenderer>().color = Yellow;
                bullet.GetComponent<BulletController>().mode = BulletMode.normal;
                shootCoolTimer = 0;
            }
            else if (Input.GetButton("Fire2") && potatoEnergy > 0)//番茄模式
            {
				GameSound.instance.Play_Shoot(GameSound.instance.Shoot);
                isShoot = true;//傳遞給小香腸 可射出
                potatoEnergy -= 1;//能量減少
                GameObject newBul = Instantiate(bullet, newPos, transform.rotation);
                newBul.GetComponent<SpriteRenderer>().color = Red;

                bullet.GetComponent<BulletController>().mode = BulletMode.potato;//定義子彈為番茄模式
                shootCoolTimer = 0;
            }

            else if (Input.GetButton("Fire3") && cheeseEnergy > 0)//起司模式
            {
				GameSound.instance.Play_Shoot(GameSound.instance.Shoot);
                isShoot = true;//傳遞給小香腸 可射出
                cheeseEnergy -= 1;//能量減少

                //Instantiate(bullet, newPos, transform.rotation);

                GameObject newBul = Instantiate(bullet, newPos, transform.rotation);
                newBul.GetComponent<SpriteRenderer>().color = Red;

                bullet.GetComponent<BulletController>().mode = BulletMode.cheese;
                shootCoolTimer = 0;
            }

            if (sausageShootCount == 2)
            {
                isShoot = false;
                sausageShootCount = 0;
            }
            canShoot = PublicFunction.Cool(ref shootCoolTimer, shootCoolTime);
        }

        if (sausageShootCount >= 2)
        {
            isShoot = false;
            sausageShootCount = 0;
        }
        canShoot = PublicFunction.Cool(ref shootCoolTimer, shootCoolTime);
    }

    void GetScore(float score)
    {
        this.score += score;//加分
    }

    void TakeDamage(float damage)
    {
        if (!invincible)//沒有無敵
        {
            HP -= damage;//扣血
            invincible = true;
        }
    }

    public void ChangeSauceMode(SauceMode saucemode)
    {
        if (!this.saucemode.Contains(saucemode))//如果玩家沒有這個佐料
        {
            this.saucemode.Add(saucemode);//將佐料加入
        }
    }

    void Anim()
    {


        if ((int)HP == 3)
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Normal[Anim_idx];
        else if ((int)HP == 2)
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Second[Anim_idx];
        else if ((int)HP == 1)
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Third[Anim_idx];

        horizontal = Input.GetAxis("Horizontal");

        if (Anim_Clock >= Anim_Frequent)
        {
            if (horizontal > 0)
            {
                Anim_idx = 5;
            }
            else if (horizontal < 0)
            {
                Anim_idx = 4;
            }
            else
            {
                if (Anim_idx == 3 || Anim_idx == 4 || Anim_idx == 5)
                    Anim_idx = 0;
                else
                    Anim_idx++;

                Anim_Clock = 0.0f;
            }
        }

    }

    void SauceAbility(SauceMode saucemode)
    {
        switch (saucemode)
        {
            case SauceMode.potato:
            case SauceMode.Shrimp:
            case SauceMode.greenpepper:
                this.saucemode.Remove(saucemode);//純加分直接移除
            break;

            case SauceMode.pineapple:
                if (isShieldExist == false)
                {
                    Instantiate(shield, player.transform.position, player.transform.rotation);//生成防護罩
                    isShieldExist = true;
                }
                break;
            case SauceMode.greenBean://青豆
                if (Input.GetButton("Fire1") || Input.GetButton("Fire2") || Input.GetButton("Fire3"))
                {
                    if (Mathf.Abs(shootCoolTime / 2 - shootCoolTimer) <= 0.01)
                        Instantiate(greenBeanBullet, player.transform.position, player.transform.rotation);
                }
                break;
            case SauceMode.sausage://小香腸
                if (Input.GetButton("Fire1") || Input.GetButton("Fire2") || Input.GetButton("Fire3"))
                {
                    if (isSausageExist == false)
                    {
                        Instantiate(sausageBullet, new Vector3(player.transform.position.x - 0.5f, player.transform.position.y, player.transform.position.z), player.transform.rotation);
                        Instantiate(sausageBullet, new Vector3(player.transform.position.x + 0.5f, player.transform.position.y, player.transform.position.z), player.transform.rotation);
                        isSausageExist = true;
                    }
                }
                break;
            case SauceMode.chili://辣椒
                bullet.GetComponent<BulletController>().saucemode = SauceMode.chili;
                bullet.GetComponent<BulletController>().damage = 2;
                break;
            case SauceMode.mushroom://香菇
                /*bullet.GetComponent<SpriteRenderer>().sprite = bullet.GetComponent<BulletController>().mushroomBullet;
                bullet.GetComponent<BulletController>().moveSpeed = 0.5f;*/
                break;
        }
    }
}