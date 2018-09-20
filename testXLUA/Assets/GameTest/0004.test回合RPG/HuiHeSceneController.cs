using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuiHeSceneController : MonoBehaviour {

	// Use this for initialization

    public GameObject[] playerCharacters;
    public GameObject[] enemyCharacters;

    public GameObject magicFXPrefab;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void PlayerOneMagicAttackWithNoDelay()
    {
        TheCharacter character=this.playerCharacters[0].GetComponent<TheCharacter>();
        character.magicCastDone = new TheCharacter.MagicCastDone(this.MagicCastDone);
        character.MagicCast();
        //character.GotHit();



    }

    public void MagicCastDone()
    {
        Debug.Log("MagicCastDone");

        TheCharacter enemyCharacter = this.enemyCharacters[0].GetComponent<TheCharacter>();
        enemyCharacter.GotHit();
        this.AddFx(enemyCharacter.gameObject);
    }





    public void AddFx(GameObject gameObj)
    {
        Instantiate(magicFXPrefab, gameObj.transform);
    }

}
