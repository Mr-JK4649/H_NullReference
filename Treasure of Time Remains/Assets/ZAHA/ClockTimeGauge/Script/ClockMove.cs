using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ClockMove : MonoBehaviour
{
    const float angle360 = 360;
    Image second_clockimage;

    [SerializeField] GameObject second;
    [SerializeField] GameObject clockGauge_ogj;
    ClockGauge clockGauge;

    float second_timeangle;

    public float Remaininggauge;//残りゲージ処理追加

    // Start is called before the first frame update
    void Start()
    {
        clockGauge = clockGauge_ogj.GetComponent<ClockGauge>();
        second_clockimage = GetComponent<Image>();
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        ////時間計算処理
        //nowtime += Time.deltaTime; //加算

        if (second_clockimage.fillAmount > 0)
        {
            //秒針を左回りに回転
            second.transform.eulerAngles = new Vector3(0f, 0f, (float)clockGauge.time / 60 * angle360);
        }

        //秒針角度生成
        second_timeangle = (float)clockGauge.time / 60 * angle360;

        Remaininggauge = 60 - clockGauge.time;//残りゲージ処理

        ScoreManager.Instance.keptAbility = (int)Remaininggauge;
        //エモート表示処理
        second_clockimage.fillAmount = 1 - (second_timeangle / 360);


    }
}
