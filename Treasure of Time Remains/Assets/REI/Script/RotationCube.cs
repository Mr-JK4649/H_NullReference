using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chronos;

public class RotationCube : MonoBehaviour
{
    public GlobalClock _GlobalClock;
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
        if (script[1].timeScale == 1)
        {
            transform.Rotate(new Vector3(x, y, z));
        }


    }
}
