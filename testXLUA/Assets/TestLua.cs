using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLua : MonoBehaviour {

	// Use this for initialization
	void Start () {
        LuaManager.GetInstance().DoString("require 'Download/hehe'");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
