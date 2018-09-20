using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderAdapt : MonoBehaviour {

    public Camera theUICamera;

    float designHeight = 640.0f;
    float designWidth=1136f;

	// Use this for initialization
	void Start () {

        this.ResizeCamera();
	}
	
	// Update is called once per frame
	void Update () {

#if UNITY_EDITOR
        //for test
        this.ResizeCamera();
#endif

    }

    void ResizeCamera()
    {
        float screenRatio =(float) Screen.height /(float) Screen.width;
        float designRatio=designHeight / designWidth;

        if (screenRatio > designRatio)
        {
            //more thin
            float newSize = 1 / (Screen.width / designWidth);
            theUICamera.orthographicSize = newSize;   
        }
        else
        {
            float newSize = 1 / (Screen.height / designHeight);
            theUICamera.orthographicSize = newSize;   
        }
    }
}
