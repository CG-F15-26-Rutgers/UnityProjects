using UnityEngine;
using System.Collections;

public class BigBoxMoveable : MonoBehaviour
{

    bool dragEnabled = false;
    Vector3 dragStartPosition;
    float dragStartDistance;
    void OnMouseDown()
    {
        dragEnabled = true;
        dragStartPosition = transform.position;
        dragStartDistance = (Camera.main.transform.position - transform.position).magnitude;
    }
    void Update()
    {
        if (Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1))
        {
            dragEnabled = false;
        }
    }
    void OnMouseDrag()
    {
        if (dragEnabled)
        {
            Vector3 worldDragTo = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, dragStartDistance));
            //Vector3 dragZ = Camera.main.ScreenToWorldPoint(new Vector3(dragStartDistance, Input.mousePosition.y, Input.mousePosition.z));
            transform.position = new Vector3(worldDragTo.x, dragStartPosition.y, worldDragTo.z);
        }
    }
}
