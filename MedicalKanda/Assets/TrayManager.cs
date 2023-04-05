using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrayManager : MonoBehaviour
{
    private int organsPlacedCorrectly = 0;

    public void OrganPlacedCorrectly()
    {
        organsPlacedCorrectly++;
        Debug.Log("Organs placed correctly: " + organsPlacedCorrectly);

        if (organsPlacedCorrectly >= 3)
        {
            OpenDoor();
        }
    }

    public void OrganRemoved()
    {
        organsPlacedCorrectly--;
        Debug.Log("Organs placed correctly: " + organsPlacedCorrectly);
    }

    private void OpenDoor()
    {
        // Code to open the door goes here
    }
}
