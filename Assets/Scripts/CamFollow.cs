using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform Target;
    public float followSpeed = 10f;

    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, Target.position, followSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, Target.rotation, followSpeed * Time.deltaTime);
    }
}
