using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VegLerp : MonoBehaviour
{
    public float CleanCount;
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "water")
        {
            Destroy(other.gameObject);
            Debug.Log("aaaa");
            //CleanCount;
        }
    }
}