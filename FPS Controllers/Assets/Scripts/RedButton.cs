using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedButton : Usable
{
    public GameObject cannon;

    private void Start()
    {
        cannon = GameObject.FindGameObjectWithTag("Cannon");
    }

    public override void Use()
    {
        Debug.Log("Right");
        cannon.GetComponent<Cannon>().RotateRight();
    }
}
