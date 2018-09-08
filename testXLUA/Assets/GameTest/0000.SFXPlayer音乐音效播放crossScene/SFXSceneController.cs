using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SFXSceneController : MonoBehaviour {

    public UnityEngine.Audio.AudioMixer mixer;

	// Use this for initialization
	void Start () {
        mixer.SetFloat("BGMVolumn", -20.0f);

        float theVolumn;
        mixer.GetFloat("BGMVolumn", out theVolumn);
        Debug.Log(">>>>>>>>" + theVolumn);
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void CrossScene()
    {
        SceneManager.LoadScene("SFXPlayer2");
    }
}
