using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScript : MonoBehaviour
{
    public bool objectGrabbed;
    public GameObject grabbedObject;


    void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            ShootRay();
        }
        if (Input.GetMouseButtonUp(0))
        {
            DropObject();
        }
    }

    void ShootRay()
    {
        // Bit shift the index of the layer (3) to get a bit mask
        int layerMask = 1 << 3;

        // This would cast rays only against colliders in layer 3.

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log("Did Hit");
            GrabObject(hit.collider);
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 100, Color.white);
            Debug.Log("Did not Hit");
            DropObject();
        }
    }

    void GrabObject(Collider obj)
    {
        objectGrabbed = true;
        grabbedObject = obj.gameObject;
    }

    void DropObject()
    {
        objectGrabbed = false;
        grabbedObject = null;
    }
}
