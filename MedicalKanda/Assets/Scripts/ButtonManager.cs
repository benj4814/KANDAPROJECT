using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    private int buttonsPressed = 0;

    // Reference to the OpenDoor script attached to the door GameObject
    public OpenDoor doorOpener;

    public void ButtonPressed()
    {
        buttonsPressed++;

        if (buttonsPressed == 3)
        {
            doorOpener.Open();
        }

        Debug.Log("Button pressed " + buttonsPressed + " times");
    }
}
