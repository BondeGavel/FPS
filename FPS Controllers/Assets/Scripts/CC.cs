using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CC : MonoBehaviour {

    [SerializeField]
    float moveSpeed = 10f, gravity = 20f, jumpForce = 10f, sprintSpeed = 20f, walkSpeed = 10f;

    Vector3 moveDirection;
    CharacterController controller;

    
    void Start () {
        controller = GetComponent<CharacterController>();
	}
	
	void Update () {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputZ = Input.GetAxisRaw("Vertical");

        float strafe = (inputX != 0 && inputZ != 0) ? .7f : 1f; // Kill speed on strafe :) Return 1 if not strafing

        if (Input.GetKeyDown("left shift"))
            moveSpeed = sprintSpeed;
        else if (Input.GetKeyUp("left shift"))
            moveSpeed = walkSpeed;

        if (controller.isGrounded)
        {
            moveDirection = new Vector3(inputX, 0, inputZ) * moveSpeed;
            moveDirection *= strafe;
            moveDirection = transform.TransformDirection(moveDirection);

            if (Input.GetKeyDown("space"))
                moveDirection.y = jumpForce;
        }

        moveDirection.y -= gravity * Time.deltaTime;

        controller.Move(moveDirection * Time.deltaTime); // Move the cracater with CC

        Debug.Log(usable);
        if (Input.GetKey(KeyCode.E) && usable != null)
            usable.Use();
	}

    //IUsable usable;
    Usable usable;
    private void OnTriggerEnter(Collider other)
    {
        //MonoBehaviour[] scripts = other.gameObject.GetComponents<MonoBehaviour>();
        //foreach (var script in scripts)
        //{
        //    if (script is IUsable)
        //        usable = (IUsable)script;
        //}

        usable = other.gameObject.GetComponent<Usable>();
    }

    private void OnTriggerExit(Collider other)
    {
        usable = null;
    }
}
