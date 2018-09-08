using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadController : MonoBehaviour {

    public GameObject cameraPrefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void LoadScene()
    {
        //Scene sceneC = SceneManager.GetSceneByName("ControllersScene");
        //Scene sceneX = SceneManager.GetSceneByName("BuildingScene");

        //SceneManager.MergeScenes(sceneC, sceneX);

        //ControllersScene
        SceneManager.LoadSceneAsync("BuildingScene");
        SceneManager.sceneLoaded += OnSceneLoaded;
        

    }

    private void OnSceneLoaded(Scene i_loadedScene, LoadSceneMode i_mode)
    {
        Debug.LogFormat("OnSceneLoaded() current:{0} loadedScene:{1} mode:{2}", SceneManager.GetActiveScene().name, i_loadedScene.name, i_mode);


        Instantiate(cameraPrefab);
    }


}
