using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheCharacter : MonoBehaviour {

    public Texture texIdle;
    public Texture texMagicCast;
    public Texture texGotHit;

    public Renderer rend;
	// Use this for initialization
	void Start () {
        //this.Idle();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Idle()
    {
        rend.material.mainTexture = texIdle;
    }

    public void MagicCast()
    {
        CancelInvoke("Idle");
        rend.material.mainTexture = texMagicCast;
        Invoke("Idle", 3);
    }

    public void GotHit()
    {
        CancelInvoke("Idle");
        rend.material.mainTexture = texGotHit;
        Invoke("Idle", 3);
    }

    

}
