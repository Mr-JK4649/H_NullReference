using UnityEngine;
using UnityEngine.UI;

public class TimeGauge : MonoBehaviour
{
    [SerializeField] private GameObject me;     //ゲームオブジェクト
    [SerializeField] private Image guageCircle; //ゲージ画像
    [SerializeField] private Text tex;          //残り時間表示
    [SerializeField] private float limit;       //タイムリミット
    public float time;                          //タイム
    public bool isActive;

    private void Awake()
    {
        me.SetActive(false);
        isActive = false;
        time = limit;
    }

    public void GuageUpdate()
    {
        if (!isActive)
        {
            me.SetActive(true);
            isActive = true;
            //time = limit;
        }

        if (isActive)
        {
            time -= Time.deltaTime;
            if (time <= 0) { TimeEnd(); time = 0; }
            guageCircle.fillAmount = time / limit;
            tex.text = (guageCircle.fillAmount * limit).ToString("0.0");
        }
    }

    public void TimeEnd()
    {
        me.SetActive(false);
        isActive = false;
        //time = 0;
    }

    
}
