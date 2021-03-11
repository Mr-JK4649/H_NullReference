using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpPoint : MonoBehaviour
{
    
    //public Vector3 pos;

    public TimeControl time;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Death")
        {

            time.RewindStart();
        }
    }
}