using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chronos;

public class Swing : MonoBehaviour
{
    //進んでいる方向
    private int direction = 1;
    //Z軸の角度
    private float angle = 0f;
    //動き始める時の時間
    private float startTime;
    //補間間隔
    [SerializeField]
    private float duration = 5f;
    //Z軸で振り子をする角度
    [SerializeField]
    private float limitAngle = 90f;

    GameObject TimeKeeper;                      //時間制御のｽｸﾘﾌﾟﾄが入ってるオブジェクト
    GlobalClock[] script = new GlobalClock[2];  //クロックを入れる用の配列

    void Start()
    {
        TimeKeeper = GameObject.Find("Timekeeper");
        script = TimeKeeper.GetComponents<GlobalClock>();
        startTime = Time.time;
    }

    //Update is called once per frame
    void FixedUpdate()
    {
        if (script[0].timeScale == 1 && script[1].localTimeScale == 1)
        {
            //経過時間に合わせた割合を計算
            float t = (Time.time - startTime) / duration;
            //スムーズに角度を計算
            angle = Mathf.SmoothStep(angle, direction * limitAngle, t);
            //角度を変更
            transform.localEulerAngles = new Vector3(angle, 0f, 0f);
            //角度が指定した角度と1度の差になったら反転
            if (Mathf.Abs(Mathf.DeltaAngle(angle, direction * limitAngle)) < 1f)
            {
                direction *= -1;
                startTime = Time.time;
            }
        }
    }

    //進んでいる向きを返す(実際にはint値)
    public int GetDirection()
    {
        return direction;
    }
}
