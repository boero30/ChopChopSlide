using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPoint : MonoBehaviour
{
    float xRot, yRot = 0.0f;

    public Rigidbody veg;

    public float rotspeed = 5f;

    public float power = 30f;

    public LineRenderer line;

    // Update is called once per frame
    void Update()
    {
        transform.position = veg.position;

        if (Input.GetMouseButton(0))
        {
            xRot += Input.GetAxis("Mouse X") * rotspeed;
            yRot += Input.GetAxis("Mouse Y") * rotspeed;
            if (yRot < -5f){
                yRot = -5f;
            }
            if (yRot > 5f)
            {
                yRot = 5f;
            }
            if (xRot < -100f)
            {
                xRot = -100f;
            }
            if (xRot > 100)
            {
                xRot = 100f;
            }
            transform.rotation = Quaternion.Euler(yRot, xRot, 0);
            line.gameObject.SetActive(true);
            line.SetPosition(0,transform.position);
            line.SetPosition(1, transform.position + transform.forward*4f);
        }

        if (Input.GetMouseButtonUp(0))
        {
            veg.velocity = transform.forward * power;
            line.gameObject.SetActive(false);
        }
    }
}
