using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitPanelController : MonoBehaviour {

    public FuckExitPanel fuckExitPanel;
    private bool flag = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void TestShow()
    {
        if (!flag)
        {
            ShowUpPanel();
            flag = true;
        }
        else
        {
            DismissPanel();
            flag =false;
        }
    }


    public void ShowUpPanel()
    {
        fuckExitPanel.ShowUp();
    }

    public void DismissPanel()
    {
        fuckExitPanel.Hide();
    }
}
