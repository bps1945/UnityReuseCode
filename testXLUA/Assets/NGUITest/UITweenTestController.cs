using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITweenTestController : MonoBehaviour {

    public UISprite theSprite;
    public TweenAlpha tweenAlpha;
    public TweenScale tweenScale;

	void Start () {

        EventDelegate.Add(tweenAlpha.onFinished, ScaleDone);
        tweenAlpha.gameObject.SetActive(false);
	}

    void ScaleDone()
    {
        theSprite.gameObject.SetActive(false);
        
    }


    public void Show()
    {
        theSprite.gameObject.SetActive(true);
        theSprite.alpha = 1.0f;
        tweenScale.ResetToBeginning();
        tweenScale.PlayForward();

    }

    public void Hide()
    {
        tweenAlpha.gameObject.SetActive(true);
        tweenAlpha.ResetToBeginning();
        tweenAlpha.PlayForward();
    }

}
