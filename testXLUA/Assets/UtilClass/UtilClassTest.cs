using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilClassTest : MonoBehaviour {

	// Use this for initialization
	void Start () {

        PlayerData.SetLoggedInServerIDs(new int[2]{1001,1002});

        int[] hehe=PlayerData.GetLoggedInServerIDs();

        foreach (int i in hehe)
        {
            Debug.Log(i);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
