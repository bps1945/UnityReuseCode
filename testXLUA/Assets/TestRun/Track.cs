using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Track : MonoBehaviour {


    public Transform headObj;
    public Transform tailObj;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Translate(new Vector3(0,0,-10*Time.deltaTime));
	}
}
