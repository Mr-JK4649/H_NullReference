using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chronos;

public class FloatObject : MonoBehaviour
{
    public int limit = 100; //移動時間
    int counter = 0; //これがリミットより大きくなると移動止める
    bool IsArea　= false;
    public float movespeed_x = 0f;
    public float movespeed_y = 0f;
    public float movespeed_z = 0f;　

    GameObject TimeKeeper;
    GlobalClock[] script = new GlobalClock[2];

    void Start()
    {
        TimeKeeper = GameObject.Find("Timekeeper");
        script = TimeKeeper.GetComponents<GlobalClock>();
    }

    private void Update()
    {
        if (script[0].timeScale == 1 && script[1].localTimeScale == 1 && Time.timeScale != 0 && IsArea)
        {
            Vector3 p = new Vector3(movespeed_x, movespeed_y, movespeed_z);
            transform.Translate(p);
            counter++;
        }


        //countがlimitになれば止める
        if (counter == limit)
        {
            counter = 0;
            movespeed_z = 0;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")//プレイヤーにあたったらIsAeraをonにするから移動する
        {
            IsArea = true;

        }
    }
}