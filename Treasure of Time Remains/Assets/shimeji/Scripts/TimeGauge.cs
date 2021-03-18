using UnityEngine;
using UnityEngine.UI;

public class TimeGauge : MonoBehaviour
{
    [SerializeField] private Slider timeGauge;  //時間操作ゲージ
    [SerializeField] private Text abilityTex;   //能力テキスト
    [SerializeField] private Text timeTex;      //残り時間表示
    [SerializeField] private float limit;       //タイムリミット
    public float time;                          //タイム
    public bool isActive;

    private void Awake()
    {
        //me.SetActive(false);
        isActive = false;
        time = limit;
        timeTex.text = (timeGauge.value * limit).ToString("0.0");
    }

    private void FixedUpdate()
    {
        //ゲージの数値化
        timeTex.text = (timeGauge.value * limit).ToString("0.0");

        
    }

    public void GuageUpdate(float timeNum)
    {
        if (!isActive)
        {
            //me.SetActive(true);
            isActive = true;
            //time = limit;
        }

        if (isActive)
        {
            time -= Time.deltaTime;
            if (time <= 0) { TimeEnd(); time = 0; }

            timeGauge.value = time / limit;
        }

        //発動中の能力を表示
        if (timeNum == 0) abilityTex.text = "Time Stop";
        if (timeNum == -1) abilityTex.text = "Time Rewind";
        if (timeGauge.value == 0) abilityTex.text = "Non Activate";
    }

    public void TimeEnd()
    {
        //me.SetActive(false);
        isActive = false;
        //time = 0;
    }

    public void Recover(float rtime)
    {
        time += rtime;
        if (limit <= time)
        {
            time = limit;
        }
    }


}
