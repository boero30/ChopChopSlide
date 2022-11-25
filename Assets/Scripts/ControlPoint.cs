using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
            SceneManager.LoadScene(12);
        }
        if (other.gameObject.tag == "knife")
        {
            lose = true;
            if(tomato == true)
            {
                SceneManager.LoadScene(26);
            }
            else if (onion == true)
            {
                SceneManager.LoadScene(23);
            }
            else if (egg == true)
            {
                SceneManager.LoadScene(20);
            }
            else if (avo == true)
            {
                SceneManager.LoadScene(14);
            }
            else if (carrot == true)
            {
                SceneManager.LoadScene(18);
            }
        }
        if (other.gameObject.tag == "fry")
        {
            if (tomato == true)
            {
                SceneManager.LoadScene(27);
            }
            else if (onion == true)
            {
                SceneManager.LoadScene(24);
            }
            else if (egg == true)
            {
                SceneManager.LoadScene(21);
            }
            else if (avo == true)
            {
                SceneManager.LoadScene(15);
            }
            else if (carrot == true)
            {
                SceneManager.LoadScene(17);
            }
        }
        if (other.gameObject.tag == "boil")
        {
            if (tomato == true)
            {
                SceneManager.LoadScene(25);
            }
            else if (onion == true)
            {
                SceneManager.LoadScene(22);
            }
            else if (egg == true)
            {
                SceneManager.LoadScene(19);
            }
            else if (avo == true)
            {
                SceneManager.LoadScene(15);
            }
            else if (carrot == true)
            {
                SceneManager.LoadScene(17);
            }
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
