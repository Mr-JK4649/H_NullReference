using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock_Animation : MonoBehaviour
{
    Animator clock_animation;


    // Start is called before the first frame update
    void Start()
    {
        clock_animation = GetComponent<Animator>();
    }

    public void Clock_On()
    {
        clock_animation.SetBool("ClockMove",true);
    }

    public void Clock_Off()
    {
        clock_animation.SetBool("ClockMove", false);
    }
}
