using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LookAround : MonoBehaviour
{
    float rotateX = 0f;
    float rotateY = 0f;

    public float sensitivity = 15f;

    void Update()
    {
        rotateX += Input.GetAxis("Horizontal") * sensitivity;
        rotateY += Input.GetAxis("Vertical") * -1 * sensitivity;
        transform.localEulerAngles = new Vector3(rotateX, rotateY, 0);
    }
}
