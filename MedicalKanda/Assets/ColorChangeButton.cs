using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class ColorChangeButton : MonoBehaviour
{
    public Material redMaterial; // Assign your red material to this variable in the Inspector
    public Material greenMaterial; // Assign your green material to this variable in the Inspector

    private Renderer buttonRenderer;

    void Start()
{
    buttonRenderer = GetComponent<Renderer>();
    buttonRenderer.material = redMaterial;
    Debug.Log("Button material set to red");
}

   void Update()
{
    if (Input.GetKeyDown(KeyCode.E))
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject == gameObject)
            {
                buttonRenderer.material = greenMaterial;
                Debug.Log("Button material set to green");
            }
            else
            {
                Debug.Log("Raycast hit something else");
            }
        }
        else
        {
            Debug.Log("Raycast did not hit anything");
        }
    }
}
}

