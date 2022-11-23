using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerBar : MonoBehaviour
{
    public Slider force;
    public Controlpoint control;
    public float lastvalue;
    public float power;


    // Start is called before the first frame update
    public void Start()
    {
        force = GetComponent<Slider>();
        force.maxValue = 8f;
        force.value = 0f;
    }

    // Update is called once per frame
    public void Update()
    {

        if (Input.GetButton("Power"))
        {
            if (force.value < 8f)
            {
                force.value = force.value + 0.01f;
            } else
            {
                force.value = 8f;
            }
        }

        if (Input.GetButtonUp("Power"))
        {
            force.value = force.value;
            Debug.Log(force.value);
        }
    }

    public void Reset()
    {
        force.value = 0f;
    }

}
