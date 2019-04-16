using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropProp : MonoBehaviour {
    public int max;
    public int chance;
    int num;
    public GameObject showPic;
	// Use this for initialization
	void Start () {
        }
	
	// Update is called once per frame
	void Update () {
		
	}

    void GetLuck()
    {
        num = UnityEngine.Random.Range(0, max);
        if (num <= chance) DropProp();
    }

    void DropProp()
    {
        showPic.SetActive(true);
    }

}
