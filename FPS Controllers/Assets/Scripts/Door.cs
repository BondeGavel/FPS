using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class Door : MonoBehaviour, IUsable
//{
//    public void Use() // Use on door
//    {
//        GetComponent<Animator>().SetTrigger("UseDoor");
//    }
//}

//public interface IUsable
//{
//    void Use();
//}
    
    public abstract class Usable : MonoBehaviour
    {
    public abstract void Use();
    }

    public class Door : Usable
    {
        public override void Use()
        {
            GetComponent<Animator>().SetTrigger("UseDoor");
        }
    }
