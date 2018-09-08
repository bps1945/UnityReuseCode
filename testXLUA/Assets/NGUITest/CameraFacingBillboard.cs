using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraFacingBillboard : MonoBehaviour
{
   

    void Update()
    {
        transform.LookAt(transform.position + Camera.current.transform.rotation * Vector3.forward,
            Camera.current.transform.rotation * Vector3.up);
    }


}