using UnityEngine;
using UnityEngine.UI;

public class TimeGauge : MonoBehaviour
{
    [SerializeField] private Slider timeGauge;  //時間操作ゲージ
    [SerializeField] private Text abilityTex;   //能力テキスト
    [SerializeField] private Text timeTex;      //残り時間表示
    [SerializeField] private bool s_FullTime;   //スタート時にマックスするか  
    [SerializeField] private float limit;       //タイムリミット
    public float time;                          //タイム
    public bool isActive;                       //能力がアクティブかどうか

    private void Awake()
    {
        //me.SetActive(false);
        isActive = false;
        //if(s_FullTime)time = limit;
        timeTex.text = (timeGauge.value * limit).ToString("0.0");
    }

    private void FixedUpdate()
    {
        //ゲージの数値化
        timeGauge.value = time / limit;
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

            
        }

        //発動中の能力を表示
        if (timeNum == 0) abilityTex.text = "タイムストップ";            //停止中
        if (timeNum == -1) abilityTex.text = "Time Rewind";         //逆行中
        if (timeNum == 1) abilityTex.text = "Accel";                //加速中
    }

    public void TimeEnd()
    {
        //me.SetActive(false);
        isActive = false;
        //time = 0;

        abilityTex.text = "ノンアクティブ";         //通常
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
