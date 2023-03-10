using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUpDrop : MonoBehaviour {


    [SerializeField] private Transform playerCameraTransform;
    [SerializeField] private LayerMask pickUpLayerMask;
   
   private void update() {
    if (Input.GetKeyDown(KeyCode.E)) {
        float pickUpDistance = 2f;
    if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit RaycastHit, pickUpDistance, pickUpLayerMask))
        if (RaycastHit.transform.TryGetComponent(out ObjectGrabbable objectGrabbable)) {
            Debug.Log(objectGrabbable);
        }
    }
   }
}
