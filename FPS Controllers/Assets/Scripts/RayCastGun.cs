using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastGun : MonoBehaviour {

    [SerializeField]
    float range = 100, rateOfFire = 0.1f;
    float shotDuration = 0.2f;
    float nextShot;

    [SerializeField]
    Transform gunEnd;

    [SerializeField]
    ParticleSystem muzzleFlash;

    LineRenderer laser;
    Camera cam;

	// Use this for initialization
	void Start () {
        laser = GetComponent<LineRenderer>();
        laser.enabled = false;
        cam = Camera.main;

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Fire1") && Time.time > nextShot)
        {
            Shoot();
        }
	}

    private void Shoot()
    {
        nextShot = Time.time + rateOfFire; // Current time + rate of fire
        laser.SetPosition(0, gunEnd.position);

        StartCoroutine(ShotEffect());
        RaycastHit hit;
        // Origin, riktning, information, range
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            laser.SetPosition(1, hit.point); // Laser stops at impact
        }
        else
        {
            laser.SetPosition(1, cam.transform.position + (cam.transform.forward * range));
        }
    }

    // coroutine
    IEnumerator ShotEffect()
    {
        laser.enabled = true;
        muzzleFlash.Play();

        yield return new WaitForSeconds(shotDuration);
        laser.enabled = false;
    }
}
