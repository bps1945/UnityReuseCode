using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuiHeSceneController : MonoBehaviour {

	// Use this for initialization

    public GameObject[] playerCharacters;
    public GameObject[] enemyCharacters;


	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void PlayerOneMagicAttackWithNoDelay()
    {
        TheCharacter character=this.playerCharacters[0].GetComponent<TheCharacter>();
        character.MagicCast();
    }

}
