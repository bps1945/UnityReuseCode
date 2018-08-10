using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class TheButtonController : MonoBehaviour {

    public UISprite controlButton;

    public UISprite[] itemButtons;
    public Vector3[] buttonPositions;

    public float animationTime = 0.8f;
    public Vector3 rotateAngle = new Vector3(0, 0, -90);

	// Use this for initialization
	void Start () {
        buttonPositions = new Vector3[itemButtons.Length];
        for (int i = 0; i < buttonPositions.Length; i++)
        {
            buttonPositions[i] = itemButtons[i].transform.localPosition;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ControlButtonTouched()
    {
        Debug.Log("ControlButtonTouched");

        //itemButtons[0].transform.DOLocalMove(controlButton.transform.position,3.0f);

        if (this.IsExpanded())
        {
            Debug.Log("IsExpanded");
            this.Shrink();
        }
        else if (this.IsShrinked())
        {
            Debug.Log("IsShrinked");
            this.Expand();
        }

        Debug.Log(controlButton.transform.localEulerAngles);
        Debug.Log(rotateAngle);
    }



    private void Shrink()
    {
        foreach (UISprite itemButton in itemButtons)
        {
            itemButton.transform.DOLocalMove(controlButton.transform.position, animationTime);
            itemButton.transform.DOLocalRotate(rotateAngle, animationTime);
        }
        controlButton.transform.localEulerAngles = rotateAngle;
    }

    private void Expand()
    {
        for (int i=0;i<buttonPositions.Length;i++)
        {
            UISprite itemButton = itemButtons[i];
            itemButton.transform.DOLocalMove(buttonPositions[i], animationTime);
            itemButton.transform.DOLocalRotate(Vector3.zero, animationTime);
        }
        controlButton.transform.localEulerAngles = Vector3.zero;
    }

    bool IsExpanded()
    {
        return Vector3.zero == controlButton.transform.localEulerAngles;   
    }

    bool IsShrinked()
    {
        return rotateAngle.z + 360 == controlButton.transform.localEulerAngles.z;
    }





}
