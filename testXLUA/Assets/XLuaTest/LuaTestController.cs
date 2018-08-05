using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuaTestController : MonoBehaviour {

    public XLuaTool xLuaTool;

	// Use this for initialization
	void Start () {
        //xLuaTool.DoString(@"CS.UnityEngine.Debug.Log('Hello world')");


	}

    public void Fix()
    {
        xLuaTool.DoString(@"
                xlua.hotfix(CS.TestClass, 'SayHi', function(self)
                    print('say hi from lua')
                end)
            ");
    }


	// Update is called once per frame
	void Update () {
		
	}
}
