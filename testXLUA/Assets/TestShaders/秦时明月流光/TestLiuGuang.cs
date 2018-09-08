using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLiuGuang : MonoBehaviour {

    UITexture theTex;

    public Material mat;
	// Use this for initialization

    //float offset = -1.0f;

    Vector2 currentOffset;

    public float scrollSpeed = 0.5F;

	void Start () {
        theTex = this.GetComponent<UITexture>();
        
	}
	
	// Update is called once per frame
	void Update () {
        //theSprite.material.SetFloat("",);
        //Texture tex= theSprite.material.GetTexture("_OverlapTex");
        //tex.get

        //offset-=0.005f;
        //if (offset >= 0)
        //{
        //    offset = -1.0f;


        //}

        //theTex.material.SetTextureOffset("_OverlapTex", new Vector2(offset, 0));

        //mat.SetTextureOffset("_OverlapTex", new Vector2(offset, 0));
        ////theSprite.material.SetTextureOffset("_OverlapTex", new Vector2(offset, 0));

        //Debug.Log("offset:"+ offset);


        if (Input.GetKey(KeyCode.U))
        {
            //currentOffset.y += Time.deltaTime;
            //gameObject.GetComponent<UITexture>().material.mainTextureOffset = currentOffset;
            //Debug.Log("uuuuuuuu");


            float offset = Time.time * scrollSpeed;
            gameObject.GetComponent<UITexture>().material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
            Debug.Log("uuuuuuuu");
        }




	}
}
