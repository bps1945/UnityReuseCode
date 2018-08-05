using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;
public class LuaManager : MonoBehaviour {

	// Use this for initialization

    public static LuaEnv luaEnv;

    static LuaManager luaManager;

    public static LuaManager GetInstance()
    {
        if (null == luaManager)
        {
            luaManager = new LuaManager();
        }
        return luaManager;
    }

    public LuaManager()
    {
        luaEnv = new LuaEnv();
        luaEnv.DoString(string.Format("package.path='{0}/?.lua'",Application.dataPath));
    }

    //void Awake()
    //{
    //    //get an instance
    //    luaEnv = new LuaEnv();
    //    luaEnv.DoString(string.Format("package.path='{0}/?.lua'",Application.dataPath));
    //}

    public void DoString(string str)
    {
        luaEnv.DoString(str);
    }

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
