using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VegLerp : MonoBehaviour
{
    public Transform[] target;
    public float speedjump;

    private int current;

    private void Update()
    {
        if(transform.position != target[current].position)
        {
            Vector3 pos = Vector3.MoveTowards(transform.position, target[current].position, speedjump);
            GetComponent<Rigidbody>().MovePosition(pos);
        }else current = (current + 1) % target.Length;
    }
}