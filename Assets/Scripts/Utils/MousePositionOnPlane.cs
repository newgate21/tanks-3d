using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePositionOnPlane
{
    static public Vector3 GetMousePositionOnPlaneXZ()
    {
        Plane plane = new Plane(Vector3.up, Vector3.zero);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (plane.Raycast(ray, out float dist))
        {
            return ray.GetPoint(dist);
        }
        return Vector3.zero;
    }
}
