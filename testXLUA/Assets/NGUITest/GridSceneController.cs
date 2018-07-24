using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSceneController : MonoBehaviour {

	// Use this for initialization

    private ArrayList buttonList = new ArrayList();
    public GameObject cellPrefab;
    public UIGrid grid;

	void Start () {
        int cellNum = 23;

        for (int i = 0; i < cellNum; i++)
        {
            GameObject cellInstance = Instantiate(cellPrefab);
            cellInstance.transform.SetParent(grid.transform, false);
            TheCell theCell = cellInstance.GetComponent<TheCell>();

            buttonList.Add(theCell.theButton.gameObject);

            
            //theCell.theButton.onClick
            if(null==theCell.theButton)
            {
                Debug.Log("~~~~~~~~~~~~");
            }
            UIEventListener.Get(theCell.theButton.gameObject).onClick = ButtonTouched;
        }
    }
 

	
	// Update is called once per frame
	void Update () {
		
	}

    public void ButtonTouched(GameObject cellObj)
    {
        int touchIndex=buttonList.IndexOf(cellObj);
        
        Debug.Log("the index:" + touchIndex);
    }
}
