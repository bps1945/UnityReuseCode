using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;


public class AssetBundleTestController : MonoBehaviour {

    public Image theImage;
    public Sprite theSprite;

	// Use this for initialization
	void Start () {
        theImage.sprite = theSprite;


        //VersionUtil.VersionStrToNum("1.2.3");

        //VersionUtil.VersionCompareResult result= VersionUtil.VersionStringCompare("1.20.5", "1.5.0");
        //Debug.Log(result);

        string strMD5=Crypto.GetMD5HashFromFile(@"C:\Users\aaa\Documents\GitHub\UnityReuseCode\testXLUA\TheDownload\zip0.bundle");
        Debug.Log("the MD5:"+strMD5);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ShowVersion()
    { 
        PlayerData.GetLocalVersionCode();
    }

    public void SetVersion()
    {
        PlayerData.SetLocalVersionCode("1.9.12");
    }





    public void SetImage()
    {
        //theImage GeneratedAssetBundle

        string theURL = "file:///C:/Users/aaa/Documents/GitHub/UnityReuseCode/testXLUA/GeneratedAssetBundle/1732821.sprite";
        WWW asset = new WWW(theURL);
        AssetBundle bundle = asset.assetBundle;
        theImage.sprite = bundle.LoadAsset<Sprite>("1732821");
        //bundle.Unload(false);


        //theImage.sprite = sprite;
    }


    public void Download()
    {
        StartCoroutine(Bundles());
    }

    IEnumerator Bundles()
    {
        List<string> urlList = new List<string>();
        urlList.Add("http://localhost/zip0.bundle");
        urlList.Add("http://localhost/zip1.bundle");
        urlList.Add("http://localhost/zip2.bundle");
        urlList.Add("http://localhost/zip3.bundle");
        urlList.Add("http://localhost/zip4.bundle");
        urlList.Add("http://localhost/zip5.bundle");
        urlList.Add("http://localhost/zip6.bundle");
        urlList.Add("http://localhost/zip7.bundle");

        foreach(string urlStr in urlList)
        {
            string filename = System.IO.Path.GetFileName(urlStr);

            using (UnityWebRequest www = UnityWebRequest.Get(urlStr))
            {
                yield return www.Send();

                if (www.isNetworkError || www.isHttpError)
                {
                    Debug.Log(www.error);
                }
                else
                {
                    // Show results as text
                    //Debug.Log(www.downloadHandler.text);

                    // Or retrieve results as binary data
                    //byte[] results = www.downloadHandler.data;

                    //System.IO.File.WriteAllText(savePath, www.downloadHandler.text);
                    System.IO.File.WriteAllBytes("C:/Users/aaa/Documents/GitHub/UnityReuseCode/testXLUA/TheDownload/" + filename, www.downloadHandler.data);
                }
            }

        }
    }

}
