using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFoor : MonoBehaviour
{
    float z;
    Vector3 tmp;

    private void OnTriggerEnter(Collider other)
    {
        Vector3 tmp = transform.root.gameObject.transform.position;
        Invoke("Move",2f);
        Debug.Log("えんたー");
    }
    void Move()
    {
        Debug.Log("むーぶ");
        //tmp.z += tmp.z * 2f;
        transform.root.position = new Vector3(0f, 0f, tmp.z * 2f);
    }
}
