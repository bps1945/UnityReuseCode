using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

public class XLuaTool : MonoBehaviour {

    public LuaEnv luaEnv;

    public XLuaTool()
    {
        luaEnv = new LuaEnv();
    }
	void Start () {
        DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnDestroy()
    {
        luaEnv.Dispose();
    }

    public void DoString(string luaCodeStr)
    {
        luaEnv.DoString(luaCodeStr);
    }
}
