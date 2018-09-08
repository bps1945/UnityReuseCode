using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

    public float RspeedX = 1.0f;

    float x;
    float y;

    float minAngle = 0;
    float maxAngle = 180;

    public Transform target;

    private float distance;
    private float cameraHeight ;

    void Start()
    {
        cameraHeight = this.transform.position.y;
        distance = Vector3.Distance(target.position, this.transform.position);
    }


    void Update()
    {
        CameraRotate();
    }




    void CameraRotate()
    {
        if (Input.GetMouseButton(0))
        {

            x += Input.GetAxis("Mouse X") * RspeedX;
            y -= Input.GetAxis("Mouse Y") * RspeedX;

            //y = ClampAngle(y, minAngle, maxAngle);

            Quaternion rotateAngle = Quaternion.Euler(y, x, 0);//摄像机偏转角度

            Vector3 direction = new Vector3(0, cameraHeight, -distance);//摄像机距离物品的距离
            transform.rotation = rotateAngle;//让摄像机始终转向物品
            transform.position = target.position + rotateAngle * direction;//计算旋转多少角度摄像机需要偏移多少
            //transform.LookAt(target);

            //y = ClampAngle(y, minAngle, maxAngle);

        }
    }


    static float ClampAngle(float angle, float min, float max)
    {
        //if (angle < -360)
        //    angle += 360;
        //if (angle > 360)
        //    angle -= 360;
        return Mathf.Clamp(angle, min, max);
    }
}
