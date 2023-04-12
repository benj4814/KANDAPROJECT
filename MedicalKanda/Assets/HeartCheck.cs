using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartCheck : MonoBehaviour
{
private OrganManager organManager;

private bool wasSnapped = false; // track whether the organ was previously snapped


private void Start()
{
    organManager = GameObject.FindObjectOfType<OrganManager>();
}

private void OnTriggerStay(Collider other)
{
    if (Input.GetMouseButtonUp(0) && other.gameObject.name == "HjerteSnap" && !wasSnapped)
    {
        Debug.Log("Heart accepted");
        organManager.OrgansSnappedCorrectly();
        wasSnapped = true;
    }
}

private void OnTriggerExit(Collider other)
{
    if (other.gameObject.name == "HjerteSnap")
    {
        if (wasSnapped)
        {
            organManager.OrganRemovedSnap();
        }
        wasSnapped = false;
    }
}
}