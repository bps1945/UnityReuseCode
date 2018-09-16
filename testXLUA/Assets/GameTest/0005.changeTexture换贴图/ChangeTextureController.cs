using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTextureController : MonoBehaviour {

    public Texture texture01;
    public Texture texture02;

    public Renderer rend;
	// Use this for initialization

    public void ChangeToTex01()
    {
        rend.material.mainTexture = texture01;
    }

    public void ChangeToTex02()
    {
        rend.material.mainTexture = texture02;

    }
}
