using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controlpoint : MonoBehaviour
{
    //public GameObject cinCam

    public bool jumped = false;

    float xRot, yRot = 0.0f;

    public bool newShoot = true;

    public Rigidbody veg;

    public float rotspeed = 5f;

    //CAMERA REF
    public Transform cameraTransform;
    private Vector3 moveDirection = Vector3.zero;

    //GAMEOBJECTS REF
    public LineRenderer line;

    public Vector3 jump;

    public float jumpForce;

    public PowerBar powerBar;

    public float power;

    public bool IsMoving()
    {
        return veg.velocity.magnitude > 1f;
    }

    void Start()
    {
        jump = new Vector3(0.0f, jumpForce, 0.0f);

        power = powerBar.force.value;

        jumped = false;
    }

    public IEnumerator Shoot()
    {

        transform.position = veg.position;

        powerBar.force.value = powerBar.force.value;

        jumped = false;


        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("jumpyay");
            if (jumped == false)
            {
                //jumpForce = 1f;
                veg.AddForce(jump * jumpForce, ForceMode.Impulse);
                jumped = true;
            }
            if (jumped == true)
            {
                jumpForce = 0f;
                veg.AddForce(jump * jumpForce, ForceMode.Impulse);
            }

        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            power = 0.2f;
            veg.velocity = transform.forward * 100;

        }
        yield return new WaitForSeconds(1);

    }

    public void Update()
    {
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        moveDirection = cameraTransform.TransformDirection(moveDirection);
        //moveDirection *= power;

        if (Input.GetButton("Work"))
        {
            //jumped = false;
            StartCoroutine(Shoot());
            //powerBar.force.value = 0f;
        }
        
        if (Input.GetButton("Shoot"))
        {
            veg.velocity = moveDirection * powerBar.force.value;
            //Debug.Log(power);
            Debug.Log(powerBar.force.value);
            //powerBar.force.value = 0f;
        }
    }

}
