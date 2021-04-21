using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chronos;

public class MoveFloare_Y : MonoBehaviour
{
    GameObject TimeKeeper;
    GlobalClock[] script = new GlobalClock[2];
    int counter = 0;
    public int limit = 100; //移動時間の長さ
    public float movespeed_x = 0f;
    public float movespeed_y = 0f;
    public float movespeed_z = 0f;

    void Start()
    {
        TimeKeeper = GameObject.Find("Timekeeper");
        script = TimeKeeper.GetComponents<GlobalClock>();
    }

    void Update()
    {
        if (script[0].timeScale == 1 && script[1].localTimeScale == 1 && Time.timeScale != 0)
        {
            Vector3 p = new Vector3(movespeed_x, movespeed_y, movespeed_z);
            transform.Translate(p);
            counter++;

            //countがlimitになれば-1を掛けて逆方向に動かす
            if (counter == limit)
            {
                counter = 0;
                movespeed_y *= -1;
            }
        }
    }
}