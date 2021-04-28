using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushHari : MonoBehaviour
{
    Naname naname_aria;
    Rigidbody rb;
    bool pushflg = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pushflg)
        {
            rb.velocity = new Vector3(0f, -10f, -10f);
        }
        //if (naname_aria.push)
        //{
        //    rb.velocity = new Vector3(1f, 1f, 0f);
        //}   
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Floor")
        {
            pushflg = false;
        }
    }
}
