using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrganManager : MonoBehaviour
{
public GameObject objectToTurnGreen; // Drag the object in the inspector
public Material greenMaterial; // Drag the green material in the inspector
    private int organsSnappedCorrectly = 0;
private bool doorOpened = false;

public void OrgansSnappedCorrectly()
{
    organsSnappedCorrectly++;
    Debug.Log("Organs placed correctly: " + organsSnappedCorrectly);

    if (organsSnappedCorrectly >= 3)
    {
        OpenDoor();
    }
}

public void OrganRemovedSnap()
{
    organsSnappedCorrectly--;
    Debug.Log("Organs placed correctly: " + organsSnappedCorrectly);
}

private void OpenDoor()
{
    if (doorOpened)
    {
        Debug.Log("Door already opened");
        return;
    }

    // Get the door game object
    GameObject door = GameObject.Find("DoorPivot");

    // Rotate the door by -90 degrees on the x-axis and y-axis
    door.transform.Rotate(new Vector3(0f, -90f, 0f));

    Debug.Log("Door opened");

    doorOpened = true;

    // Change the material of the specified game object
    if (objectToTurnGreen != null)
    {
        Renderer renderer = objectToTurnGreen.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material = greenMaterial;
        }
    }
}
}
