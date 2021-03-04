using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallCube : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Hit");
            this.transform.parent.gameObject.GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
