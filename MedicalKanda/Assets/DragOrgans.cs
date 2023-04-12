using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragOrgans : MonoBehaviour
{
    private Vector3 mOffset;
    private float mZCoord;
    private bool isSnapped = false;

    public GameObject organPosition;

    void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

        // Store offset = gameobject world pos - mouse world pos
        mOffset = gameObject.transform.position - GetMouseAsWorldPoint();

        // Set isSnapped to false when the player starts dragging the heart
        isSnapped = false;
    }

    private Vector3 GetMouseAsWorldPoint()
    {
        // Pixel coordinates of mouse (x,y)
        Vector3 mousePoint = Input.mousePosition;

        // z coordinate of game object on screen
        mousePoint.z = mZCoord;

        // Convert it to world points
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    void OnMouseDrag()
    {
        if (!isSnapped)
        {
            // If the heart is not snapped to the position, allow it to be dragged by the player
            transform.position = GetMouseAsWorldPoint() + mOffset;
        }
    }

    void OnMouseUp()
    {
        // Check if the heart is snapped to the heart position
        if (!isSnapped && organPosition.GetComponent<Collider>().bounds.Contains(transform.position))
        {
            // Set isSnapped to true and snap the heart to the position when the player releases the left mouse button
            transform.position = organPosition.transform.position;
            GetComponent<Rigidbody>().isKinematic = true;
            isSnapped = true;
        }
    }
}
