using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairCursor : MonoBehaviour
{
    private void Start()
    {
        transform.rotation = Camera.main.transform.rotation;
    }
    // Update is called once per frame
    void Update()
    {
        UpdateXZPosition();
    }
    private void UpdateXZPosition()
    {
        // Keep Y position fixed
        Vector3 newPos = MousePositionOnPlane.GetMousePositionOnPlaneXZ();
        newPos.y = GameController.Instance.Player.transform.position.y;

        transform.position = newPos;
    }
}
