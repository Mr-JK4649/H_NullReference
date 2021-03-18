using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chronos;

public class TimeControl : MonoBehaviour
{
    public GameObject ie_obj;//時間停止時の色調反転のシェーダーが入ってるオブジェクト
    private ImageEffect[] ie;//シェーダー

    [SerializeField] GlobalClock _Rewinder;//全体の巻き戻し

    [SerializeField] GlobalClock _Stopper;//オブジェクトの時間停止用

    [SerializeField] private TimeGauge _StopGauge;
    [SerializeField] private TimeGauge _RewindGauge;
    [SerializeField] private Animator ethan;
    private float originSpeed;

    // Start is called before the first frame update
    void Start()
    {
        ie = ie_obj.GetComponents<ImageEffect>();
        ie[0].enabled = false;
        ie[1].enabled = false;
        originSpeed = ethan.GetFloat("Speed");
    }

    private void Update()
    {
        //巻き戻し用
        if (Input.GetKey(KeyCode.R) || Input.GetButton("ContL1"))
            _Rewinder.localTimeScale = -1;
        //else _Rewinder.localTimeScale = 1; 
        if (Input.GetKeyUp(KeyCode.R) || Input.GetButtonUp("ContL1"))
            _Rewinder.localTimeScale = 1;
            

            Process(ie[0], _Rewinder, _RewindGauge);
        if(_Rewinder.localTimeScale != -1)
            ethan.SetFloat("Speed", _Rewinder.localTimeScale);


        //停止用
        if (Input.GetKeyDown(KeyCode.T) || Input.GetButtonDown("ContR1"))
            _Stopper.localTimeScale = 0;
        if (Input.GetKeyUp(KeyCode.T) || Input.GetButtonUp("ContR1"))
            _Stopper.localTimeScale = 1;
            //else _Stopper.localTimeScale = 1;

            Process(ie[1], _Stopper, _StopGauge);
        
    }

    public void RewindStart()//死亡時に巻き戻す
    {
        _Rewinder.localTimeScale = -1;
    }

    //時間操作の関数
    private void Process(ImageEffect ie,GlobalClock cl,TimeGauge ga) {

        //時間の速度が通常じゃなければ
        if (cl.localTimeScale != 1)
        {

            ie.enabled = true;

            ga.GuageUpdate();
            if (!ga.isActive)
            {
                cl.localTimeScale = 1;
                ie.enabled = false;
            }
        }
        else { ga.TimeEnd(); ie.enabled = false;}
    }
}