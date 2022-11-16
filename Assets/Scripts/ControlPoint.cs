using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controlpoint : MonoBehaviour
{
    public bool jumped = false;

    float xRot, yRot = 0.0f;

    public bool newShoot = true;

    public Rigidbody veg;

    public float rotspeed = 5f;

    public float power;

    public LineRenderer line;

    public Vector3 jump;

    public float jumpForce = 1f;

    public PowerBar powerBar;

    //public bool isGrounded;

    public bool IsMoving()
    {
        return veg.velocity.magnitude > 1f;
    }

    void Start()
    {
        jump = new Vector3(0.0f, jumpForce, 0.0f);

        //power = 0f;

        jumped = false;
    }

    public IEnumerator Shoot()
    {
        transform.position = veg.position;

        powerBar.force.value = powerBar.force.value;

        if (Input.GetMouseButton(0))
        {
            xRot += Input.GetAxis("Mouse X") * rotspeed;
            yRot += Input.GetAxis("Mouse Y") * rotspeed;
            if (yRot < -40f)
            {
                yRot = -40f;
            }
            if (yRot > 40f)
            {
                yRot = 40f;
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
            line.SetPosition(0, transform.position);
            line.SetPosition(1, transform.position + transform.forward * 4f);

            powerBar.force.value = 0f;
        }

        if (Input.GetMouseButtonUp(0))
        {
            veg.velocity = transform.forward * power;
            //line.gameObject.SetActive(false);
            powerBar.force.value = 0f;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (jumped == false)
            {
                jumpForce = 1f;
                veg.AddForce(jump * jumpForce, ForceMode.Impulse);
                jumped = true;
            }else if (jumped == true)
            {
                jumpForce = 0f;
                veg.AddForce(jump * jumpForce, ForceMode.Impulse);
            }

        }

        if (Input.GetKeyDown(KeyCode.F)) //freeze
        {
            power = 0.2f;
            veg.velocity = transform.forward * power;

        }
        yield return new WaitForSeconds(1);

        //powerBar.force.value = 0;
    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.S))
        {
            StartCoroutine(Shoot());
            powerBar.force.value = 0f;
        }
    }
    


}
