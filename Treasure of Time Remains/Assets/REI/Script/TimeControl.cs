﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chronos;

public class TimeControl : MonoBehaviour
{
    public InvertEffect ie;

    private GlobalClock _GlobalClock;

    // Start is called before the first frame update
    void Start()
    {
        _GlobalClock = GetComponent<GlobalClock>();
        ie.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            _GlobalClock.localTimeScale = 1 - _GlobalClock.localTimeScale;
        }
        if (_GlobalClock.localTimeScale == 0)
        {
           // _GlobalClock.localTimeScale = 1;
            ie.enabled = true;

        }
        else
        {
           // _GlobalClock.localTimeScale = 0;
            ie.enabled = false;
        }

    }
}