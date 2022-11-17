using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LookAround : MonoBehaviour
{
    public float speedHor = 3f;
    public float speedVer = 3f;

    private float yaw = 0f;
    private float pitch = 0f;

    void Update()
    {
        //if (Input.GetMouseButton(1))
        //{
            yaw += speedHor * Input.GetAxis("Mouse X");
            pitch -= speedVer * Input.GetAxis("Mouse Y");

            transform.eulerAngles = new Vector3(pitch, yaw, 0f);
        //}
    }
}
