using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gButton : Usable
{
    public GameObject cannon;
    public void Start()
    {
        cannon = GameObject.FindGameObjectWithTag("Cannon");
    }

    public override void Use()
    {
        Debug.Log("Left");
        cannon.GetComponent<Cannon>().RotateLeft();
    }
}
