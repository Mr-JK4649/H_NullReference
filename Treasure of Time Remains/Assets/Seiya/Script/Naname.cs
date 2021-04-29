using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Naname : MonoBehaviour
{
    public bool push;
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            push = true;
        }
    }
}