using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {


    [SerializeField]
    float xMin = -60f, xMax = 60f; // Min/max for up & down

    [SerializeField]
    float sensitivity = 1f;

    float rotationX;
    float rotationY;

	// Use this for initialization
	void Start () {
        Cursor.lockState = CursorLockMode.Locked; // hide mouse
	}
	
	// Update is called once per frame
	void Update () {


        rotationX += Input.GetAxis("Mouse Y") * sensitivity; // Mouse X = mouse movement
        rotationY += Input.GetAxis("Mouse X") * sensitivity;

        rotationX = Mathf.Clamp(rotationX, xMin, xMax); // Value can only be between numbers

        transform.localEulerAngles = new Vector3(0, rotationY, 0);
        Camera.main.transform.localRotation = Quaternion.Euler(-rotationX, 0, 0); // Add rotation to only camera

        if (Input.GetKeyDown(KeyCode.Escape))
            Cursor.lockState = CursorLockMode.None; // Show mouse on escape

    }
}
