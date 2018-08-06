using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class HotUpdate : MonoBehaviour {

    const int FILE_LIST_DOWNLOAD_RETRY_TIME = 3;
    List<FileItem> urlList = new List<FileItem>();

    public class FileItem
    { 
        public string fileURL;
        public string fileMD5;
        public bool downloadSuccess=false;

        public FileItem(string fileURL,string fileMD5)
        {
            this.fileURL = fileURL;
            this.fileMD5 = fileMD5;
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

    public void Download()
    {
        StartCoroutine(UpdateClient());
    }

    IEnumerator UpdateClient()
    {
        //List<string> urlList = new List<string>();
        //urlList.Add("http://localhost/zip0.bundle");
        //urlList.Add("http://localhost/zip1.bundle");
        //urlList.Add("http://localhost/zip2.bundle");
        //urlList.Add("http://localhost/zip3.bundle");
        //urlList.Add("http://localhost/zip4.bundle");
        //urlList.Add("http://localhost/zip5.bundle");
        //urlList.Add("http://localhost/zip6.bundle");
        //urlList.Add("http://localhost/zip7.bundle");


        FileItem fileItem0 = new FileItem("http://localhost/zip0.bundle", "C509A83B43CF8631783F2BA83A49EAD8");
        FileItem fileItem1 = new FileItem("http://localhost/zip0.bundle", "C509A83B43CF8631783F2BA83A49EAD8");
        FileItem fileItem2 = new FileItem("http://localhost/zip0.bundle", "C509A83B43CF8631783F2BA83A49EAD8");
        FileItem fileItem3 = new FileItem("http://localhost/zip0.bundle", "C509A83B43CF8631783F2BA83A49EAD8");
        FileItem fileItem4 = new FileItem("http://localhost/zip0.bundle", "C509A83B43CF8631783F2BA83A49EAD8");
        FileItem fileItem5 = new FileItem("http://localhost/zip0.bundle", "C509A83B43CF8631783F2BA83A49EAD8");
        FileItem fileItem6 = new FileItem("http://localhost/zip0.bundle", "C509A83B43CF8631783F2BA83A49EAD8");
        FileItem fileItem7 = new FileItem("http://localhost/zip0.bundle", "C509A83B43CF8631783F2BA83A49EAD8");

       
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
                if (!fileItem.downloadSuccess)
                {
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
                            //System.IO.File.WriteAllText(savePath, www.downloadHandler.text);
                            string filePersistPath = "C:/Users/aaa/Documents/GitHub/UnityReuseCode/testXLUA/TheDownload/" + filename;
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
