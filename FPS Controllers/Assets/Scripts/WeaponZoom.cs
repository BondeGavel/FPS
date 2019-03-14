using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponZoom : MonoBehaviour {

    [SerializeField]
    Transform zoomPosition;
    [SerializeField]
    float zoomTime = 25f;

    Vector3 startPosition;

	// Use this for initialization
	void Start () {
        startPosition = transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, zoomPosition.localPosition, zoomTime *Time.deltaTime); // move over time
        }
        else
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, startPosition, zoomTime * Time.deltaTime);
        }
		
	}
}
