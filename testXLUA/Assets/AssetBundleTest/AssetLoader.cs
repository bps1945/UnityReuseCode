using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class AssetLoader : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
    //public string Get


	// Update is called once per frame
	void Update () {
		
	}

    public static GameObject GetUIPrefab(string fileName)
    {
        string assetBundleFilePath = GetAssetBundleDownloadedPath("UIPrefab", fileName.ToLower()+".prefab");
        WWW asset = new WWW(assetBundleFilePath);
        GameObject prefab=null;
        AssetBundle bundle = asset.assetBundle;
        if(bundle)
        {
            prefab = bundle.LoadAsset<GameObject>(fileName);//please keep the filename and the prefab name same
        }
        if (prefab)
        {
            return prefab;
        }
        else
        {
            string resourcesFilePath = GetFileInResourcesFolderPath("UIPrefab", fileName);
            return Resources.Load(resourcesFilePath) as GameObject;
        }
    }

    public static string GetAssetBundleDownloadedPath(string folder,string fileName)
    {
        string path = Application.persistentDataPath + Path.DirectorySeparatorChar + folder + Path.DirectorySeparatorChar + fileName;
        Debug.Log(path);
        return path;
    }

    public static string GetFileInResourcesFolderPath(string folder, string fileName)
    {
        return "UIPrefab" + Path.DirectorySeparatorChar + fileName;
    }

}
