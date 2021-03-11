﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chronos;

public class TimeControl : MonoBehaviour
{
    public InvertEffect ie;//時間停止時の色調反転のシェーダー

    private GlobalClock _GlobalClock;

    [SerializeField] private TimeStopGuage _guage;

    // Start is called before the first frame update
    void Start()
    {
        _GlobalClock = GetComponent<GlobalClock>();
        ie.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T) || Input.GetButtonDown("Action1"))
        {
            _GlobalClock.localTimeScale = 1 - _GlobalClock.localTimeScale;
            _guage.TimeStart();
        }
        if (_GlobalClock.localTimeScale == 0)
        {
           // _GlobalClock.localTimeScale = 1;
            ie.enabled = true;
            
            _guage.GuageUpdate();
            if (!_guage.isStop) _GlobalClock.localTimeScale = 1;
        }
        else
        {
           // _GlobalClock.localTimeScale = 0;
            ie.enabled = false;

            _guage.TimeEnd();
        }

    }
}