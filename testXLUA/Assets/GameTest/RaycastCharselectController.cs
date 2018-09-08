using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastCharselectController : MonoBehaviour {

    public GameObject[] gameObjects;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("GetMouseButtonUp");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo))
            {
                //if (hitInfo.collider.gameObject == groundObject)
                //{
                //    targetPosition = hitInfo.point;
                //}

                foreach (GameObject obj in gameObjects)
                {
                    if (hitInfo.collider.gameObject == obj)
                    {
                        Renderer rend = obj.GetComponent<Renderer>();

                        //Set the main Color of the Material to green
                        rend.material.shader = Shader.Find("_Color");
                        rend.material.SetColor("_Color", Color.green);
                        break;
                    }
                
                }
            }
        }
	}
}
