using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chronos;

public class TimeControl : MonoBehaviour
{
    public InvertEffect ie;//時間停止時の色調反転のシェーダー

    [SerializeField] GlobalClock _Rewinder;//全体の巻き戻し

    [SerializeField] GlobalClock _Stopper;//オブジェクトの時間停止用

    [SerializeField] private TimeStopGuage _guage;
    [SerializeField] private TimeRewindGuage _guage_rewind;

    // Start is called before the first frame update
    void Start()
    {
        //_Rewinder = GetComponent<GlobalClock>();
        ie.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T) || Input.GetButtonDown("Action1"))
        {
            _Stopper.localTimeScale = 1 - _Stopper.localTimeScale;
            _guage.TimeStart();
        }
        if (_Stopper.localTimeScale == 0)//停止用
        {
            ie.enabled = true;
            
            _guage.GuageUpdate();
            if (!_guage.isStop) _Stopper.localTimeScale = 1;
        }
        else
        {
            ie.enabled = false;

            _guage.TimeEnd();
        }

        if (_Rewinder.localTimeScale == -1) //巻き戻し用
        {
            // _Rewinder.localTimeScale = 1;
            ie.enabled = true;

            _guage_rewind.GuageUpdate();
            if (!_guage_rewind.isRewind) _Rewinder.localTimeScale = 1;
        }
        else
        {
            // _Rewinder.localTimeScale = 0;
            ie.enabled = false;

            _guage_rewind.TimeEnd();
        }

    }

    public void RewindStart()//死亡時に巻き戻す
    {
        _Rewinder.localTimeScale = -1;
        _guage_rewind.TimeStart();
    }
}