using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerBar : MonoBehaviour
{
    public Slider force;
    public Controlpoint control;
    public float lastvalue; 

    // Start is called before the first frame update
    void Start()
    {
        force = GetComponent<Slider>();
        force.maxValue = 15f;
        force.value = 0f;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(2))
        {
            if(force.value < 15f)
            {
                force.value = force.value + 0.5f;
            }else
            {
                force.value = 15f;
            }  
        }

        if (Input.GetMouseButtonUp(2))
        {
            control.power = force.value;
            Debug.Log(force.value);
            lastvalue = force.value;
        }

        /*if (Input.GetKeyDown(KeyCode.S))
        {
            force.value = force.value;
        }*/
    }
}
