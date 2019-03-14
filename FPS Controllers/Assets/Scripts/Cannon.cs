using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public void RotateLeft()
    {
        transform.Rotate(-transform.up);
    }

    public void RotateRight()
    {
        transform.Rotate(transform.up);
    }
}