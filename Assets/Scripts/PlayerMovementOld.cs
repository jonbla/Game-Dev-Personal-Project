using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementOld : MonoBehaviour
{
    public float speed;
    public float rotationSensitivity;

    private float delta;

    public Vector2 mouseDelta;

    private float horizontal;
    private float vertical;

    Transform child;

    // Start is called before the first frame update
    void Start()
    {
        child = transform.Find("Player Head");

        Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        if (horizontal != 0)
        {
            CalculateMovement(horizontal);
            transform.position += transform.right * delta;
        }

        vertical = Input.GetAxis("Vertical");
        if (vertical != 0)
        {
            CalculateMovement(vertical);
            transform.position += transform.forward * delta;
        }

        CalculateMouseDelta();
        RotateCamera();
    }

    void CalculateMovement (float val)
    {
        delta = Time.deltaTime * speed * val;
    }

    void CalculateMouseDelta()
    {
        mouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")) * rotationSensitivity * Time.deltaTime;
    }

    void RotateCamera()
    {
        transform.Rotate(0, mouseDelta.x, 0, Space.World);
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0);

        child.Rotate(mouseDelta.y , 0, 0, Space.Self);
        child.localRotation = Quaternion.Euler(child.localRotation.eulerAngles.x, child.localRotation.eulerAngles.y, 0); 
    }
}
