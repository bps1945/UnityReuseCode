using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotificationCenter : MonoBehaviour {

	// Use this for initialization


    public delegate void Call(object param0, object param1,object param2);//第一步：定义委托类型

    private static NotificationCenter instance=null;

    Dictionary<string, Call> dictionary = new Dictionary<string, Call>();

	void Start () {
        //unity inspector型单例
        this.Init();
	}

    void Init()
    {
        if (null == instance)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            if (this.gameObject != instance.gameObject)
            {
                Debug.Log("Destroy new instance");
                Destroy(this.gameObject);
            }
        }    
    }

    public NotificationCenter GetInstance()
    {
        if (null == instance)
        {
            this.Init();
        }
        return instance;
    }

	// Update is called once per frame
	void Update () {
		
	}


    public void RegisterNotification(string notification, Call call)
    {
        //dictionary.Add(notification, call);
        if (dictionary.ContainsKey(notification))
        {
            Call theCall = dictionary[notification];
            theCall += call;
        }
        else
        {
            dictionary.Add(notification, call);
        }

    }

    public void UnRegisterNotification(string notification)
    {
        //dictionary.Remove(notification);
        if (dictionary.ContainsKey(notification))
        {
            dictionary.Remove(notification);
        }
    }

    public void UnRegisterNotification(string notification,Call call)
    {
        //dictionary.Remove(notification);
        if (dictionary.ContainsKey(notification))
        {
            Call theCall = dictionary[notification];
            theCall -= call;
            dictionary[notification] = theCall;
        }
    }

    public void PostNotification(string notification, object param0, object param1, object param2)
    {
        Call theCall = dictionary[notification];
        theCall(param0, param1, param2);
    }

    //new Call(objMath.Multiply);
}
