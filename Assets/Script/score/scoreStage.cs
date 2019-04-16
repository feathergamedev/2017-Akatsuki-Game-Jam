using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class scoreStage : MonoBehaviour {

    public float score;
    int hp;
    public Sprite[] pizza;
    public GameObject[] ingre;
    public GameObject[] text;
    public int n = 0;
    float count;
    bool stop = false;
    int pren;

    public int totalAmount;

    // Use this for initialization
    void Start () {
        score = GameManager.instance.Score;
        hp = (int)PlayerController.instance.HP;

        this.gameObject.GetComponent<SpriteRenderer>().sprite = pizza[hp];

        // ingredients
       

    }

    // Update is called once per frame
    void Update () {
        count += Time.deltaTime;


        if (count >= 0.5f )
        {
            //pren = n;
            //n = (int)(count * 1000) % 6;
            ////                    if (n != pren)
            ////                  {
            //GameObject newItem = Instantiate(ingre[n], new Vector3(0, 7.5f + 3 * n, 0), transform.rotation);
            //newItem.transform.SetParent(this.gameObject.transform);
            ////                }
            //totalAmount++;
            //count = 0.0f; 
            if (score > 70)
            {
                if (totalAmount < 15)
                {
                    int n = (UnityEngine.Random.Range(0, 100)) % 6;
                    GameObject piece = Instantiate(ingre[n], new Vector3(-0.7f+n*0.25f, 7.5f, 0), transform.rotation);
                    piece.GetComponent<SpriteRenderer>().sortingOrder = totalAmount;
                    totalAmount++;
                }
                else text[0].SetActive(true);
            }

            else if (score > 50)
            {
                if (totalAmount < 7)
                {
                    int n = (UnityEngine.Random.Range(0, 100)) % 6;
                    GameObject piece = Instantiate(ingre[n], new Vector3(-0.7f + n * 0.25f, 7.5f, 0), transform.rotation);
                    piece.GetComponent<SpriteRenderer>().sortingOrder = totalAmount;
                    totalAmount++;
                }
                else text[1].SetActive(true);
            }
            else if (score > 30)
            {
                if (totalAmount < 4)
                {
                    int n = (UnityEngine.Random.Range(0, 100)) % 5;
                    GameObject piece = Instantiate(ingre[n], new Vector3(-0.7f + n * 0.25f, 7.5f, 0), transform.rotation);
                    piece.GetComponent<SpriteRenderer>().sortingOrder = totalAmount;
                    totalAmount++;
                }
                else text[2].SetActive(true);
            }
            else if (score > 20)
            {
                if (totalAmount < 4)
                {
                    int n = (UnityEngine.Random.Range(0, 100)) % 5;
                    GameObject piece = Instantiate(ingre[n], new Vector3(-0.7f + n * 0.25f, 7.5f, 0), transform.rotation);
                    piece.GetComponent<SpriteRenderer>().sortingOrder = totalAmount;
                    totalAmount++;
                }
                else text[3].SetActive(true);
            }
            else if (score > 10)
            {
                if (totalAmount < 3)
                {
                    int n = (UnityEngine.Random.Range(0, 100)) % 3;
                    GameObject piece = Instantiate(ingre[n], new Vector3(-0.7f + n * 0.25f, 7.5f, 0), transform.rotation);
                    piece.GetComponent<SpriteRenderer>().sortingOrder = totalAmount;
                    totalAmount++;
                }
                else text[4].SetActive(true);
            }
            else if (score == 0)
            {
                text[5].SetActive(true);
            }
            else
            {
                if (totalAmount < 2)
                {
                    int n = UnityEngine.Random.Range(0, 3);
                    GameObject piece=Instantiate(ingre[n], new Vector3(-0.7f + n * 0.25f, 7.5f, 0), transform.rotation);
                    piece.GetComponent<SpriteRenderer>().sortingOrder = totalAmount;
                    totalAmount++;
                }
                else text[5].SetActive(true);
            }
            count -= 0.5f;
        }

    }
}
