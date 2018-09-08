using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{

    Vector3 dist;
    float posX;
    float posY;

    bool beingDragged;

    void Update()
    {
        if (Input.touchCount == 1)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Debug.Log("Began");
                beingDragged = true;
                this.OnTouchBegan();
            }
                
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                beingDragged = false;
                this.OnTouchEnd();
            }
        }

        if (beingDragged)
        {
            this.OnDrag();
        }
    }

    void OnTouchBegan()
    {
        dist = Camera.main.WorldToScreenPoint(transform.position);
        posX = Input.mousePosition.x - dist.x;
        posY = Input.mousePosition.y - dist.y;
    }

    void OnTouchEnd()
    { 
    
    }

    void OnDrag()
    {
        Vector3 curPos = new Vector3(Input.mousePosition.x - posX, Input.mousePosition.y - posY, dist.z);
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(curPos);
        transform.position = worldPos;
    }
}
