using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowAndHide : MonoBehaviour {

	// Use this for initialization

    bool isShow = true;
    public float speed=0.5f;

    public UIWidget widget;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log("111111");

        Color color = widget.color;
        Debug.Log(color.a);
        float incDec = 1.0f;
        if (isShow)
        {
            incDec = -1.0f;
        }
        color.a += incDec * speed * Time.deltaTime;


        if (color.a >= 1)
        {
            isShow = true;
        }
        else if (color.a <= 0)
        {
            isShow = false;
        }
        widget.color = color;
	}
}
