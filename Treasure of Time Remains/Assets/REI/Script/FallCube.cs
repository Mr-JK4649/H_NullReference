using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chronos;

[RequireComponent(typeof(Rigidbody))]
public class FallCube : MonoBehaviour
{
    GameObject TimeKeeper;
    GlobalClock[] script = new GlobalClock[2];
    bool IsFall = false;
    void Start()
    {
        TimeKeeper = GameObject.Find("Timekeeper");
        script = TimeKeeper.GetComponents<GlobalClock>();
    }

    void Update()
    {
        if (script[0].localTimeScale == 1 && script[1].localTimeScale == 1 && IsFall)//能力使ってないとき
        {
           //this.transform.parent.gameObject.GetComponent<Rigidbody>().useGravity = true;
        }
        else if(IsFall == true)
        {
            this.transform.parent.gameObject.GetComponent<Rigidbody>().useGravity = false;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Hit");
            IsFall = true;
            this.transform.parent.gameObject.GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
