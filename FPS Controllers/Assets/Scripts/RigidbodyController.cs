using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyController : MonoBehaviour {

    float walkspeed = 500f;

    [SerializeField]
    float sprintspeed = 1000f;
    [SerializeField]
    float defaultWalkspeed = 500f;

    Rigidbody rb;
    Vector3 moveDirection;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>(); // Get the Rigidbody on the object script is attached to
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown("left shift")) // Increase walkspeed when holding down left shift
            walkspeed = sprintspeed;
        if (Input.GetKeyUp("left shift"))   // Reset walkspeed when releasing shift
            walkspeed = defaultWalkspeed;
        if (Input.GetKeyDown("space"))
            Jump();
        float xMove = Input.GetAxisRaw("Horizontal"); // GetAxis.Raw is only 1, 0 or -1.
        float zMove = Input.GetAxisRaw("Vertical");   // Getaxis increases and decreases between -1 & 1

        moveDirection = (xMove * transform.right + zMove * transform.forward).normalized; // right indicates x, forward indicates z (up indicates y)
	}

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector3 gravity = new Vector3(0f, rb.velocity.y, 0f);
        rb.velocity = moveDirection * walkspeed * Time.deltaTime; // Applicate movement, deltatime makes it frame indipendent
        rb.velocity += gravity;
    }

    private void Jump()
    {
        rb.AddForce(Vector3.up * 800);
        Debug.Log("Jump");
    }
}
