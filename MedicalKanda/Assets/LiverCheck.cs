using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiverCheck : MonoBehaviour
{
private OrganManager organManager;

private bool wasSnapped = false; // track whether the organ was previously snapped


private void Start()
{
    organManager = GameObject.FindObjectOfType<OrganManager>();
}

private void OnTriggerStay(Collider other)
{
    if (Input.GetMouseButtonUp(0) && other.gameObject.name == "LiverSnap" && !wasSnapped)
    {
        Debug.Log("Liver accepted");
        organManager.OrgansSnappedCorrectly();
        wasSnapped = true;
    }
}

private void OnTriggerExit(Collider other)
{
    if (other.gameObject.name == "LiverSnap")
    {
        if (wasSnapped)
        {
            organManager.OrganRemovedSnap();
        }
        wasSnapped = false;
    }
}
}