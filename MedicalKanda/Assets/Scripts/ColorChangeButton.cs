using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangeButton : MonoBehaviour
{
    public Material redMaterial; // Denne variable goer at man kan tilfoeje sin RedMaterial i Inspectoren
    public Material greenMaterial; // Denne variable goer at man kan tilfoeje sin Groen i Inspectoren

// Dette er de private variabler, som man ikke skal se i inspectoren men som scriptet skal bruge
    private Renderer buttonRenderer;
    private ButtonManager buttonManager;
    private bool buttonClicked = false;

    void Start()
    {
        buttonRenderer = GetComponent<Renderer>(); // Denne kode finder Component MeshRenderer
        buttonRenderer.material = redMaterial; // Denne kode giver MeshRenderer RedMaterial
        
        buttonManager = GameObject.Find("GameManager").GetComponent<ButtonManager>(); // Denne kode finder vores GameManager i inspectoren og derefter vores script ButtonManager
    }

    void Update()
    {
        if (!buttonClicked && Input.GetKeyDown(KeyCode.Mouse0)) // Hvis man ikke har klikket paa Button saa eksekvere den de 3 linjer kode under
        {
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0)); // Denne kode goer at button ved om vores "player" ser paa den
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == gameObject) // Denne kode tjekker om man klikker og rammer vores button
                {
                    buttonRenderer.material = greenMaterial; // Denne kode goer at vores MeshRendere aendrere sig til GreenMaterial
                    buttonClicked = true; // Saetter vores ButtonClicked til True, saa man ikke kan klikke paa button igen.

                    buttonManager.ButtonPressed(); // Naar man har klikket paa button koerer den funktionen ButtonPressed, som ligger i ButtonManager scriptet
                }
            }
        }
    }
}

