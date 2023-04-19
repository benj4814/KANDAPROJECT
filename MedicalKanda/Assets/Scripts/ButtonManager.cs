using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    private int buttonsPressed = 0; 

    // Referencen til vores OpenDoor script
    public OpenDoor doorOpener;

    public void ButtonPressed()
    {
        buttonsPressed++; // Dette goer, at vores ButtonPressed bliver + med 1 naar vi klikker

        if (buttonsPressed == 3) // Hvis ButtonPressed bliver = 3, saa koerer den scriptet DoorOpener
        {
            doorOpener.Open();
        }

        Debug.Log("Button pressed " + buttonsPressed + " times");
    }
}
