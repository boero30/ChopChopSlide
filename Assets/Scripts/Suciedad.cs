using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suciedad : MonoBehaviour
{
    public Material MAT;
    public Controlpoint controlpoint;

    public float min = 0;
    public float max = 1;

    void Start()
    {
        MAT.SetFloat("_Opacity_Dirt", min / max);
    }

    public void Update()
    {
        if (Input.GetButton("Shoot"))
        {
            min += 0.1f;
            MAT.SetFloat("_Opacity_Dirt", min / max);
            Debug.Log(min);
        }
    }
}