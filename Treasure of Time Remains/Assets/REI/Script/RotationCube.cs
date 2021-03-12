using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chronos;

//[RequireComponent(typeof(Rigidbody))]
public class RotationCube : MonoBehaviour
{
    GameObject TimeKeeper;
    GlobalClock[] script = new GlobalClock[2];
    public float x;
    public float y;
    public float z;


    void Start()
    {
        TimeKeeper = GameObject.Find("Timekeeper");
        script = TimeKeeper.GetComponents<GlobalClock>();
    }
    // Update is called once per frame
    void Update()
    {
        if (script[0].timeScale == 1 && script[1].localTimeScale == 1)
        {
            transform.Rotate(new Vector3(x, y, z));
        }

        //if(script[1].timeScale == 0)
        //{
        //    this.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        //}else
        //    this.gameObject.GetComponent<Rigidbody>().isKinematic = false;
    }
}
