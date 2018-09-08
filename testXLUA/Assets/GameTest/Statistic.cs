using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statistic : MonoBehaviour {

    private int fps = 0;
    private float fpstime = 0;
    private int fpstick = 0;

    void Awake()
    {
        //useGUILayout = false;
    }

    // Use this for initialization
    void Start()
    {
        fpstime = 0.0f;
        fps = 0;
        fpstick = 0;
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        fpstime += Time.deltaTime;
        fpstick++;

        if (fpstime > 1.0f)
        {
            fps = fpstick;//ticks per second
            fpstime = 0.0f;
            fpstick = 0;
        }
    }

    void OnGUI()
    {
        float y = Screen.height;

        y -= 20;
        GUI.Label(new Rect(0, y, Screen.width, 20), "FPS:" + fps);

        y -= 20;
        GUI.Label(new Rect(0, y, Screen.width, 20), "Mouse: " + Input.mousePosition.x + ", " + (Screen.height - Input.mousePosition.y));
    }
}
