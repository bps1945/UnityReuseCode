using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuckExitPanel : MonoBehaviour
{

    public TweenAlpha theTweenAlpha;
    public UIPanel panel;
    // Use this for initialization
    void Start()
    {
        this.panel.alpha = 0.0f;
    }

    public void ShowUp()
    {
        this.panel.gameObject.SetActive(true);
        this.panel.alpha = 0.0f;
        this.theTweenAlpha.PlayForward();
    }

    public void Hide()
    {
        this.theTweenAlpha.PlayReverse();
    }

    public void SetInactive()
    {
        if (0.0f == panel.alpha)
        {
            this.panel.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
