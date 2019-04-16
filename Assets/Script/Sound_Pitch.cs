using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Pitch : MonoBehaviour {

    AudioSource m_audio;

	// Use this for initialization
	void Start () {
        m_audio = this.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		m_audio.pitch = Time.timeScale;

	}
}
