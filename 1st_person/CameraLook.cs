using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{

    public float mouse_sensitivity = 100f;

    public Transform player_body_obj;

    private float xRotation = 0f;
    public bool look_inversion = true;

    // Start is called before the first frame update
    void Start()
    {
        // lock the cursor to the screen here
        // Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //inputs
        float mouse_x = Input.GetAxis("Mouse X") * mouse_sensitivity * Time.deltaTime;
        float mouse_y = Input.GetAxis("Mouse Y") * mouse_sensitivity * Time.deltaTime;

        //Y axis
        player_body_obj.Rotate(Vector3.up * mouse_x);

        //X axis
        if (look_inversion){
            xRotation -= mouse_y;
        }
        else{
            xRotation += mouse_y;
        }
        //prevent overrotation
        xRotation = Math.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);



    }
}
