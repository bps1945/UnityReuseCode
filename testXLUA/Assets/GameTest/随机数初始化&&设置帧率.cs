using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
public class 随机数初始化 : MonoBehaviour {

	// Use this for initialization
	void Start () {
        UnityEngine.Random.seed = (int)DateTime.Now.Ticks;

        Application.targetFrameRate = 30;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
