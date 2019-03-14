using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RBGun : MonoBehaviour {

    [SerializeField]
    float range = 100, rateOfFire = 0.2f;
    float shotDuration = 0.2f;
    float nextShot;

    [SerializeField]
    Transform gunEnd;

    [SerializeField]
    ParticleSystem muzzleFlash;

    [SerializeField]
    GameObject bulletPrefab;
    [SerializeField]
    float bulletSpeed = 300f;

    Camera cam;

    // Use this for initialization
    void Start () {
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
        nextShot = Time.time + rateOfFire;
        StartCoroutine(ShotEffect());

        GameObject bullet = Instantiate(bulletPrefab, gunEnd.position, gunEnd.rotation);
        // Shoot with velocity
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.up * bulletSpeed;

        Destroy(bullet, 2f);
    }

    IEnumerator ShotEffect()
    {
        muzzleFlash.Play();

        yield return new WaitForSeconds(shotDuration);
    }
}
