using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXControl : MonoBehaviour {

    //public GameObject fxObj;

    public float delayShowUp = 0.0f;

    [Header("How much time to remove")]
    public float showUpTime = 1.0f;

	// Use this for initialization
	void Start () {
        this.gameObject.SetActive(false);
        Invoke("ShowFX", delayShowUp);
        Invoke("RemoveFX", showUpTime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void ShowFX()
    {
        this.gameObject.SetActive(true);
    }

    private void RemoveFX()
    {
        Destroy(this.gameObject);
    }


}
