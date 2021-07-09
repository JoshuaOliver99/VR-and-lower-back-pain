using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowHead : MonoBehaviour
{
    [SerializeField] [Tooltip("Hips/Waist")] private Transform point0;
    [SerializeField] [Tooltip("Head")] private Transform point1;
    [SerializeField] private float percentOffset = 20f;

    private float offset;
    private float radiansOffY, degreesOffY;
    private float hypot;
    private float direction, h, x, y, z;

    private float initAnglarOffset;

    void Start()
    {
        // NOTE: Maybe not needed
        // Allign manipulated start position to head
        transform.position = point1.position;

        Vector3 delta = point1.position - point0.position;
        hypot = Mathf.Sqrt((delta.y * delta.y) + (delta.x * delta.x) + (delta.z * delta.z));
        initAnglarOffset = Mathf.Acos(delta.y / hypot);
    }

    void Update()
    {
        // ----- Calculate Offset
        offset = 1 + (percentOffset / 100);

        // ----- Calculate Position
        Vector3 delta = point1.position - point0.position;

        hypot = Mathf.Sqrt((delta.y * delta.y) + (delta.x * delta.x) + (delta.z * delta.z));

        direction = Mathf.Atan2(delta.x, delta.z);
        radiansOffY = Mathf.Acos(delta.y / hypot) * offset - (initAnglarOffset * percentOffset / 100);
        degreesOffY = (radiansOffY * 180) / Mathf.PI;

        y = Mathf.Cos(radiansOffY) * hypot;
        h = Mathf.Sin(radiansOffY) * hypot;

        x = Mathf.Sin(direction) * h;
        z = Mathf.Cos(direction) * h;

        transform.position = point0.position + new Vector3(x, y, z);
    }
}
