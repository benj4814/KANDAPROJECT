using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangeButton : MonoBehaviour
{
    public Material redMaterial; // Assign your red material to this variable in the Inspector
    public Material greenMaterial; // Assign your green material to this variable in the Inspector

    private Renderer buttonRenderer;
    private ButtonManager buttonManager;

    void Start()
    {
        buttonRenderer = GetComponent<Renderer>();
        buttonRenderer.material = redMaterial;
        

        buttonManager = GameObject.Find("GameManager").GetComponent<ButtonManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    buttonRenderer.material = greenMaterial;

                    buttonManager.ButtonPressed();
                }
                
            }
        }
    }
}

