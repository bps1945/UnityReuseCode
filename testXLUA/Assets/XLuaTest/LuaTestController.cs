using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using XLua;

[Hotfix]
public class LuaTestController : MonoBehaviour {

    public XLuaTool xLuaTool;

    int number=22;

    public Vector3 theVector2;

    public AudioSource theAudioSource;

    public GameObject thePrefab;

    public int[] theIntHehe;

	// Use this for initialization
	void Start () {
        //xLuaTool.DoString(@"CS.UnityEngine.Debug.Log('Hello world')");

        //xLuaTool.luaEnv.AddLoader(MyLoader);
        //xLuaTool.luaEnv.DoString("require 'hello'");

        xLuaTool.luaEnv.DoString(string.Format("package.path='{0}/?.lua'", @"C:/Users/aaa/Documents/GitHub/UnityReuseCode/testXLUA/Assets/XLuaTest"));
	}

    private byte[] MyLoader(ref string filePath)
    {
        string absPath = @"C:\Users\aaa\Documents\GitHub\UnityReuseCode\testXLUA\Assets\XLuaTest\hello.lua";
        return System.Text.Encoding.UTF8.GetBytes(File.ReadAllText(absPath));
    }


    public void SetVector3()
    {
        Debug.Log("SetVector3");
    
    }

    public void RecoverFix()
    {
        xLuaTool.DoString("xlua.hotfix(CS.LuaTestController, 'ShowResult',nil);");
    
    }

    public void Fix()
    {
//        xLuaTool.DoString(@"
//                xlua.hotfix(CS.TestClass, 'SayHi', function(self)
//                    print('say hi from lua')
//                end)
//            ");

        string path = "Assets/XLuaTest/hello.lua";

        //Read the text from directly from the test.txt file
        StreamReader reader = new StreamReader(path); 

        string data = reader.ReadToEnd();
        xLuaTool.DoString(data);

    }

    private int numberOperation(int a)
    {
        return number+a ;
    }


    public void ShowResult()
    {
        Debug.Log("ShowResult");
        //this.SetVector3();

        //theAudioSource.Play();
    }

    void MemberMethod()
    {
        Debug.Log("MemberMethod");
    }


	// Update is called once per frame
	void Update () {
		
	}
}
