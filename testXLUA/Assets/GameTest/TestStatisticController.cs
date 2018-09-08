using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestStatisticController : MonoBehaviour
{

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}



    public void ToOtherScene()
    {
        SceneManager.LoadScene("RaycastCharSelect射线选择角色");
    
    }
}
