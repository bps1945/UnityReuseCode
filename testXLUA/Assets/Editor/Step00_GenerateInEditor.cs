using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class Step00_GenerateInEditor : MonoBehaviour {





    [MenuItem("AssetBundleTest/Build AssetBundles")]
    static void BuildAllAssetBundles()
    {
        BuildPipeline.BuildAssetBundles("GeneratedAssetBundle", BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows64);
    }


}
