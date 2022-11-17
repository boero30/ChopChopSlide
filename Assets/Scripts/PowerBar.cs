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
        force.maxValue = 15f;
        force.value = 0f;
    }

    // Update is called once per frame
    public void Update()
    {

        if (Input.GetButton("Power"))
        {
            if(force.value < 15f)
            {
                force.value = force.value + 0.1f;
            }else
            {
                force.value = 15f;
            }  
        }

        if (Input.GetButtonUp("Power"))
        {
            control.power = force.value;
            Debug.Log(force.value);
        }

        /*if (Input.GetKeyDown(KeyCode.S))
        {
            force.value = force.value;
        }*/
    }
}
