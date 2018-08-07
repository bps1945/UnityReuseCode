using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;

public class ClientUpdate : MonoBehaviour {

    const int FILE_LIST_DOWNLOAD_RETRY_TIME = 3;
    List<FileItem> urlList = new List<FileItem>();
    string remoteVersionStr;

    public class FileItem
    { 
        public string fileURL;
        public string fileMD5;
        public string dir;

        public bool downloadSuccess=false;

        public FileItem(string fileURL,string dir,string fileMD5)
        {
            this.fileURL = fileURL;
            this.dir = dir;
            this.fileMD5 = fileMD5; 
        }
    }

    public void StartVersionCheck()
    {

        StartCoroutine(VersionCheck());
    }

    IEnumerator VersionCheck()
    {
        string versionCheckURL = "http://localhost/CurrentVersion.txt";

        using (UnityWebRequest www = UnityWebRequest.Get(versionCheckURL))
        {
            yield return www.Send();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                string remoteVersionStr=www.downloadHandler.text;
                remoteVersionStr = remoteVersionStr.Trim();
                if (VersionUtil.VersionFormatCheck(remoteVersionStr))
                {
                    if (VersionUtil.VersionCompareResult.GT == VersionUtil.VersionStringCompare(remoteVersionStr, PlayerData.GetLocalVersionCode()))
                    {
                        //StartCoroutine(UpdateClient());
                    }
                }
            }
        }
    }

    IEnumerator DownloadUpdateFile()
    {
        string versionCheckURL = "http://localhost/CurrentVersion.txt";

        using (UnityWebRequest www = UnityWebRequest.Get(versionCheckURL))
        {
            yield return www.Send();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                string remoteVersionStr = www.downloadHandler.text;
                remoteVersionStr = remoteVersionStr.Trim();
                if (VersionUtil.VersionFormatCheck(remoteVersionStr))
                {
                    if (VersionUtil.VersionCompareResult.GT == VersionUtil.VersionStringCompare(remoteVersionStr, PlayerData.GetLocalVersionCode()))
                    {
                        //StartCoroutine(UpdateClient());
                    }
                }
            }
        }
    }


    bool isListSuccess()
    {
        foreach (FileItem fileItem in urlList)
        {
            if (!fileItem.downloadSuccess)
            {
                return false;
            }
        }
        return true;
    }

    public void StartUpdate()
    {
        Debug.Log("StartUpdate");
        this.StartVersionCheck();
    }

    IEnumerator UpdateClient()
    {


        FileItem fileItem0 = new FileItem("http://localhost/zip0.bundle", "UIPrefab", "C509A83B43CF8631783F2BA83A49EAD8");
        FileItem fileItem1 = new FileItem("http://localhost/zip0.bundle", "UIPrefab", "C509A83B43CF8631783F2BA83A49EAD8");
        FileItem fileItem2 = new FileItem("http://localhost/zip0.bundle", "UIPrefab", "C509A83B43CF8631783F2BA83A49EAD8");
        FileItem fileItem3 = new FileItem("http://localhost/zip0.bundle", "UIPrefab", "C509A83B43CF8631783F2BA83A49EAD8");
        FileItem fileItem4 = new FileItem("http://localhost/zip0.bundle", "UIPrefab", "C509A83B43CF8631783F2BA83A49EAD8");
        FileItem fileItem5 = new FileItem("http://localhost/zip0.bundle", "UIPrefab", "C509A83B43CF8631783F2BA83A49EAD8");
        FileItem fileItem6 = new FileItem("http://localhost/zip0.bundle", "UIPrefab", "C509A83B43CF8631783F2BA83A49EAD8");
        FileItem fileItem7 = new FileItem("http://localhost/zip0.bundle", "UIPrefab", "C509A83B43CF8631783F2BA83A49EAD8");

       
        urlList.Add(fileItem0);
        urlList.Add(fileItem1);
        urlList.Add(fileItem2);
        urlList.Add(fileItem3);
        urlList.Add(fileItem4);
        urlList.Add(fileItem5);
        urlList.Add(fileItem6);
        urlList.Add(fileItem7);


        for (int i = 0; i < FILE_LIST_DOWNLOAD_RETRY_TIME; i++)
        {
            for (int j=0;j<urlList.Count;j++)
            {
                FileItem fileItem = urlList[j];
                string directoryStr = Application.persistentDataPath + Path.DirectorySeparatorChar + fileItem.dir;
                Debug.Log("Dir" + directoryStr);
                if (!Directory.Exists(directoryStr))
                {
                    Directory.CreateDirectory(directoryStr);
                }

                if (!fileItem.downloadSuccess)
                {
                    //make dir
                    string filename = System.IO.Path.GetFileName(fileItem.fileURL);
                    using (UnityWebRequest www = UnityWebRequest.Get(fileItem.fileURL))
                    {
                        yield return www.Send();

                        if (www.isNetworkError || www.isHttpError)
                        {
                            Debug.Log(www.error);
                        }
                        else
                        {
                            string filePersistPath = directoryStr + Path.DirectorySeparatorChar + filename;
                            System.IO.File.WriteAllBytes(filePersistPath, www.downloadHandler.data);

                            //verify md5
                            string fileMD5 = Crypto.GetMD5HashFromFile(filePersistPath);
                            if (fileMD5 == fileItem.fileMD5)
                            {
                                fileItem.downloadSuccess = true;
                            }
                            else
                            {
                                System.IO.File.Delete(filePersistPath);
                            }
                        }
                    }
                }
            }
        }

        bool isListSuccess = this.isListSuccess();


    }

}
