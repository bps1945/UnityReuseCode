using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSceneController : MonoBehaviour {

	// Use this for initialization

    private List<TheCell> cellList = new List<TheCell>();
    public GameObject cellPrefab;
    public UIGrid grid;

	void Start () {
        this.LayOutGrid();
    }

    public void LayOutGrid()
    {
        int cellNum = 23;

        for (int i = 0; i < cellList.Count; i++)
        {
            grid.RemoveChild(cellList[i].transform);
            Destroy(cellList[i].gameObject);
        }
        cellList.Clear();

        for (int i = 0; i < cellNum; i++)
        {
            GameObject cellInstance = Instantiate(cellPrefab);
            cellInstance.transform.SetParent(grid.transform, false);
            TheCell theCell = cellInstance.GetComponent<TheCell>();
            theCell.theLabel.text = i.ToString();
            cellList.Add(theCell);


            //theCell.theButton.onClick
            if (null == theCell.theButton)
            {
                Debug.Log("~~~~~~~~~~~~");
            }
            UIEventListener.Get(theCell.theButton.gameObject).onClick = ButtonTouched;
        }

        grid.repositionNow = true;
    }


	
	// Update is called once per frame
	void Update () {
		
	}

    public void ButtonTouched(GameObject buttonObj)
    {
        int touchIndex=-1;

        for (int i = 0; i < cellList.Count; i++)
        {
            TheCell cell = cellList[i];
            if (cell.theButton.gameObject == buttonObj)
            {
                touchIndex = i;
                break;
            }
        }

        Debug.Log("AAAAAAAAA"+touchIndex);
    }
}
