using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheCharacter : MonoBehaviour {

    public delegate void MagicCastDone();


    public Texture texIdle;
    public Texture texMagicCast;
    public Texture texGotHit;

    public Renderer rend;


    int stateMagicCast = 0;
    int stateShowMagicOnEnemy=1;
    int stateEnemyGotHit = 2;
    int stateMagicCastDone = 3;

    int currentState;

    public MagicCastDone magicCastDone;


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

        //event
        CancelInvoke("MagicCastDoneEvent");
        Invoke("MagicCastDoneEvent", 3);

        this.currentState = stateMagicCast;
    }

    public void GotHit()
    {
        CancelInvoke("Idle");
        rend.material.mainTexture = texGotHit;
        Invoke("Idle", 3);
    }

    public void MagicCastDoneEvent()
    {
        //this.currentState = stateMagicCast;

        this.currentState = stateShowMagicOnEnemy;
        this.magicCastDone();
    }

}
