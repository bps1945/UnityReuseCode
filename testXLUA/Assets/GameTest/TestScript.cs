using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour {

	// Use this for initialization
    void Start()
    {
        //Quaternion rotation = Quaternion.Euler(15, 0, 0);
        //transform.localRotation = rotation;
    }


    public Transform target;

    public float moveSpeed = 0.5f;

	// Update is called once per frame
	void Update () {
        //Vector3 relativePos = target.position - transform.position;
        //Quaternion rotation = Quaternion.LookRotation(relativePos);

        //Quaternion current = transform.localRotation;
        //transform.localRotation = Quaternion.Slerp(current, rotation, Time.deltaTime);
        //transform.Translate(0, 0, 1 * Time.deltaTime);


        //angleX += Input.GetAxis("Mouse X") * moveSpeed;
        //angleY += Input.GetAxis("Mouse Y") * moveSpeed;

        if (Input.GetMouseButton(0))
        {

            Vector3 translation = new Vector3(0.1f * Input.GetAxis("Mouse X"), 0.1f * Input.GetAxis("Mouse Y"), 0);
            transform.Translate(translation);
            transform.LookAt(target.transform);


            Quaternion current = transform.localRotation;
            Vector3 eulerAngles=current.eulerAngles;

            Debug.Log("eulerAngles.x:" + eulerAngles.x);
            if ((eulerAngles.x <= 60) && (eulerAngles.x >= 10))
            {


            }
            else
            {
                transform.Translate(-translation);
                transform.LookAt(target.transform);
            }

        }
	}
}
