using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trajectory : MonoBehaviour
{
    public Controlpoint controlsc;
    public LineRenderer linechida;

    public int numPoints = 50;
    public float timeBtwn = 1f;

    public LayerMask CollidableLayers;

    void Start()
    {
        controlsc = GetComponent<Controlpoint>();
        linechida = GetComponent<LineRenderer>();
    }

    void Update()
    {
        linechida.positionCount = numPoints;
        List<Vector3> points = new List<Vector3>();
        Vector3 startPos = controlsc.veg.transform.position;
        Vector3 startVel = controlsc.cameraTransform.up * controlsc.powerBar.force.value;
        if (controlsc.powerBar.force.value > 0)
        {
            for (float t = 0; t < numPoints; t += timeBtwn)
            {
                Vector3 newPoint = startPos + t * startVel;
                newPoint.y = startPos.y + startVel.y * t + Physics.gravity.y/2f * t * t;
                points.Add(newPoint);

                if (Physics.OverlapSphere(newPoint, 2, CollidableLayers).Length > 0)
                {
                    linechida.positionCount = points.Count;
                    break;
                }
            }
        }
        linechida.SetPositions(points.ToArray());
    }
}
