using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LungsCheck : MonoBehaviour
{
private OrganManager organManager;

private bool wasSnapped = false; // track whether the organ was previously snapped


private void Start()
{
    organManager = GameObject.FindObjectOfType<OrganManager>();
}

private void OnTriggerStay(Collider other)
{
    if (Input.GetMouseButtonUp(0) && other.gameObject.name == "LungsSnap" && !wasSnapped)
    {
        Debug.Log("Lungs accepted");
        organManager.OrgansSnappedCorrectly();
        wasSnapped = true;
    }
}

private void OnTriggerExit(Collider other)
{
    if (other.gameObject.name == "LungsSnap")
    {
        if (wasSnapped)
        {
            organManager.OrganRemovedSnap();
        }
        wasSnapped = false;
    }
}
}