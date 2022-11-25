using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controlpoint : MonoBehaviour
{
    //public GameObject cinCa

    public Rigidbody veg;

    //public GameObject veggie;

    //CAMERA REF
    public Transform cameraTransform;
    public Vector3 moveDirection = Vector3.zero;

    public Vector3 jumpdir;

    //GAMEOBJECTS REF
    public LineRenderer line;

    public Vector3 jump;

    public float jumpForce;

    public PowerBar powerBar;

    bool InTransit = false;

    public bool lose = false;

    public float score;

    public bool avo = false;

    public bool onion = false;

    public bool tomato = false;

    public bool egg = false;

    public bool carrot = false;

    public bool IsMoving()
    {
        return veg.velocity.magnitude > 1f;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "jello")
        {
            Debug.Log("jellooo:))");
        }
        if (other.gameObject.tag == "lose")
        {
            lose = true;
            Debug.Log("lose");
        }
        if (other.gameObject.tag == "block")
        {
            Debug.Log("block");
        }
    }

    void Start()
    {
        jump = new Vector3(moveDirection.x, moveDirection.y, moveDirection.z);

        jumpdir = new Vector3(moveDirection.x, 0.5f, moveDirection.z);

    }

    public IEnumerator Disparo()
    {
        //line.gameObject.SetActive(false);
        //InTransit = true;
        veg.velocity = moveDirection * powerBar.force.value;
        yield return new WaitForSeconds(3);

        powerBar.Reset();

        yield return null;
    }

    public void Update()
    {
        //line.gameObject.SetActive(true);
        //line.SetPosition(0, veg.transform.position);
        //line.SetPosition(1, veg.transform.position + moveDirection * 500f);

        if (Input.GetKey(KeyCode.A))
        {
            veg.AddForce(jumpdir * jumpForce, ForceMode.Impulse);
        }

        moveDirection = cameraTransform.forward;

        if (Input.GetButton("Shoot"))
        {
            if (InTransit == false)
            {
                StartCoroutine(Disparo());
            }
        }
    }
}
