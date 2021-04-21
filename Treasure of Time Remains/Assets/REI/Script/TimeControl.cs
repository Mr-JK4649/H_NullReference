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

    //[SerializeField] private TimeGauge _StopGauge;
    //[SerializeField] private TimeGauge _RewindGauge;
    [SerializeField] private TimeGauge timeGauge;
    [SerializeField] private Animator ethan;

    //音
    [SerializeField] private AudioClip stopSound;
    [SerializeField] private AudioClip rewindSound;
    [SerializeField] private AudioSource _audioSource;

    // Start is called before the first frame update
    void Start()
    {
        ie = ie_obj.GetComponents<ImageEffect>();
        ie[0].enabled = false;
        ie[1].enabled = false;
    }

    private void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.R) || Input.GetButton("ContL1"))       //逆行用
        {
            if(!_audioSource.isPlaying)RingSound(rewindSound);
            _Rewinder.localTimeScale = -2;
        }
        else if (Input.GetKey(KeyCode.T) || Input.GetButton("ContR1"))  //停止用
        {
            if(_Stopper.localTimeScale == 1)RingSound(stopSound);
            _Stopper.localTimeScale = 0;
        }

        if (Input.GetKeyUp(KeyCode.R) || !Input.GetButton("ContL1"))   //逆行のリセット
        {
            _Rewinder.localTimeScale = 1;
        }
        if (Input.GetKeyUp(KeyCode.T) || !Input.GetButton("ContR1") ||
            _Rewinder.localTimeScale == -2)                             //停止のリセット
        {
            _Stopper.localTimeScale = 1;
        }


        if (!Input.GetButton("ContR1") && !Input.GetButton("ContL1"))
            _audioSource.Stop();

        //操作用の関数
        Process(timeGauge);

    }

    public void RewindStart()//死亡時に巻き戻す
    {
        _Rewinder.localTimeScale = -1;
    }

    //時間操作の関数
    private void Process(TimeGauge ga)
    {

        float r = _Rewinder.localTimeScale;
        float s = _Stopper.localTimeScale;

        //時間の速度が通常じゃなければ
        if (r != 1 || s != 1)
        {

            ga.GuageUpdate(r * s);


            if (!ga.isActive)
                AbilitySwitching(1, 1);

        }
        else ga.TimeEnd();

        ImageEffectSwitching(_Rewinder.localTimeScale, _Stopper.localTimeScale);
    }

    private void AbilitySwitching(float r, float s)
    {

        _Rewinder.localTimeScale = r;
        _Stopper.localTimeScale = s;

    }

    private void ImageEffectSwitching(float r, float s)
    {

        //if (r != 1) ie[0].enabled = true;
        //else ie[0].enabled = false;

        if (s != 1) ie[1].enabled = true;
        else ie[1].enabled = false;

    }

    //音を鳴らすやつ
    private void RingSound(AudioClip name) {
        _audioSource.PlayOneShot(name);
    }
}