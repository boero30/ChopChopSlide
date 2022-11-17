using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JelloJump : MonoBehaviour
{
    public bool jello = false;

    protected float Animate;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "jello")
        {
            Debug.Log("jellooo:))");
            jello = true;
        }
    }
    void Update()
    {

    }

}
