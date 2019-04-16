using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entry_Shader : MonoBehaviour {

	public Material TransitionMaterial;

    float Time_f;
    [Range(0,1)]public float Time_Frequent;

    [Range(0,1)]public float cutOffvalue;

	void OnRenderImage(RenderTexture src, RenderTexture dst)
	{
		if (TransitionMaterial != null)
			Graphics.Blit(src, dst, TransitionMaterial);
	}

    void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (GameManager.instance.state == GameStatus.遊戲中)
            Time_f += Time.deltaTime;

        TransitionMaterial.SetFloat("_Cutoff", cutOffvalue);
        

        if (Time_f >= Time_Frequent && cutOffvalue < 1.0f)
        {
            cutOffvalue += 0.1f;
            Time_f = 0.0f;
        }
    }
}
