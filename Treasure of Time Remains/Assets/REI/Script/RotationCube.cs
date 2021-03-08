using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chronos;

public class RotationCube : MonoBehaviour
{
    private GlobalClock _GlobalClock;
    GameObject TimeKeeper;
    GlobalClock script;
    public float x;
    public float y;
    public float z;


    void Start()
    {
        TimeKeeper = GameObject.Find("Timekeeper");
        script = TimeKeeper.GetComponent<GlobalClock>();
    }
    // Update is called once per frame
    void Update()
    {
        if (script.timeScale == 1)
        {
            transform.Rotate(new Vector3(x, y, z));
        }

    }
}
