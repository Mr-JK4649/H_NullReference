using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obj_Warp : MonoBehaviour
{

    public Vector3 pos_o;
    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obj")
        {

            other.gameObject.transform.position = new Vector3(pos_o.x, pos_o.y, pos_o.z);
            other.gameObject.GetComponent<Rigidbody>().useGravity = false;
            other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}
