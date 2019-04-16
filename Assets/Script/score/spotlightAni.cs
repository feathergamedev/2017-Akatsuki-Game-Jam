using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spotlightAni : MonoBehaviour {
    public GameObject[] Anim;
    int Anim_idx;
    float _aniCount;
    // Use this for initialization
    void Start()
    {
        _aniCount = 0;
    }

    // Update is called once per frame
    void Update () {
        _aniCount += Time.deltaTime;
        if (_aniCount >= 0.3f)
        {
            Anim_idx++;
            _aniCount -= 0.3f;
        }
        switch (Anim_idx % 2)
        {
            case 0:
                Anim[0].SetActive(true);
                Anim[1].SetActive(false);
                break;
            case 1:
                Anim[1].SetActive(true);
                Anim[0].SetActive(false);
                break;
        }
    }
}