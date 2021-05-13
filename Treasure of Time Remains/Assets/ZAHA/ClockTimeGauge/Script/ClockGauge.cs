using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockGauge : MonoBehaviour
{
    public bool isActive;//能力がアクティブか
    private float limit = 60f;
  
    public float time;

    private void Awake()
    {
        isActive = false;
    }

    public void UpdateClockGauge(float timeNum)
    {

        if (!isActive)
        {
            isActive = true;
        }

        if (isActive)
        {
            time += Time.deltaTime;

            if(time >= 60) { TimeEnd(); time = 60; }
        }

        Debug.Log(timeNum);

        Debug.Log("Updateclock");
    }

    public void TimeEnd()
    {
        isActive = false;
    }

    public void Recover(float rtime)
    {
        time -= rtime;
        if (limit <= time)
        {
            time = limit;
        }
    }
}
