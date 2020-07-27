using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float sensitivity = 100f;
    public float yOffset;
    public Transform playerBody;
    private bool camUpdate = false;
    private float xRotation = 0f;
    void Update()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        if (playerBody != null)
        {
            this.transform.position = playerBody.position + new Vector3(0,yOffset,0);
        }
        if (camUpdate)
        {
            MouseAiming();
        }
    }

    void MouseAiming()
    {
        // get the mouse inputs
        float x = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float y = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        xRotation -= y;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * x);
    }
    public void UpdatePlayerBody(Transform t)
    {
        camUpdate = true;
        this.playerBody = t;
        this.transform.position = new Vector3(0, 0, 0);
    }
}
