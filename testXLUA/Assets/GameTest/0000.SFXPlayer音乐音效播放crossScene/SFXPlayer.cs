using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXPlayer : MonoBehaviour {
	//for cross secne music play
	//and volumn control

	public AudioSource audioSourceBGM;
	public AudioSource audioSourceSFX;
	public AudioSource audioSourceUI;


	public static SFXPlayer instanceRef=null;


	// Use this for initialization
	void Start () {
		if (null != instanceRef) {
			if (this.audioSourceBGM.clip != instanceRef.audioSourceBGM.clip) {
				instanceRef.audioSourceBGM.clip = this.audioSourceBGM.clip;
				instanceRef.audioSourceBGM.loop = this.audioSourceBGM.loop;
				instanceRef.audioSourceBGM.Play ();
				//instanceRef.audioSourceBGM=this.audioSourceBGM;
			}
			Destroy (this.gameObject);
		} else {
			DontDestroyOnLoad (this);
			instanceRef = this;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnDestroy()
	{

	}

	public void PlaySound(AudioClip clip)
	{
		audioSourceSFX.PlayOneShot (clip);
	}
}
