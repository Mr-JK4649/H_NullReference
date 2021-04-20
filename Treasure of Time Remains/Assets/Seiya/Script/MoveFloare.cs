using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chronos;

public class MoveFloare : MonoBehaviour
{
    GameObject TimeKeeper;
    GlobalClock[] script = new GlobalClock[2];
    int counter = 0;
    public int limit = 100;
    public float movespeed = 0.05f;

    void Start()
    {
        TimeKeeper = GameObject.Find("Timekeeper");
        script = TimeKeeper.GetComponents<GlobalClock>();
    }

    void Update()
    {
        if (script[0].timeScale == 1 && script[1].localTimeScale == 1 && Time.timeScale != 0)
        {
            Vector3 p = new Vector3(0, 0, movespeed);
            transform.Translate(p);
            counter++;

            //countが100になれば-1を掛けて逆方向に動かす
            if (counter == limit)
            {
                counter = 0;
                movespeed *= -1;
            }
        }
    }
}
