using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowAndHide : MonoBehaviour {

	// Use this for initialization

    enum State
    {
        Stay,
        FadeOut,
        FadeIn
    };

    State state=State.Stay;
    float stayVar;

    public float speed = 0.5f;
    public float stayTime = 2.0f;

    public UIWidget widget;
	void Start () {
        stayVar = stayTime;
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log("111111");

        Color color = widget.color;

        //color.a += incDec * speed * Time.deltaTime;
        if (State.Stay == this.state)
        {
			this.stayVar -= Time.deltaTime;

            if (this.stayVar <= 0)
            {
                this.state = State.FadeOut;
                //recover
                this.stayVar = stayTime;
            }
        }
        else if (State.FadeOut == this.state)
        {
            color.a -= speed;
			widget.color = color;
			if (color.a <= 0)
            {
                this.state = State.FadeIn;
            }
        }
        else if (State.FadeIn == this.state)
        {
            color.a += speed;
			widget.color = color;
			if (color.a >= 1.0f)
            {
                this.state = State.Stay;
            }
        }
	}
}
