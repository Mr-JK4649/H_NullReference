using UnityEngine;
using UnityEngine.UI;

public class TimeRewindGuage : MonoBehaviour
{
    private GameObject me;
    [SerializeField] private Image guageCircle; //ゲージ画像
    [SerializeField] private Text tex;          //残り時間表示
    [SerializeField] private float limit;       //タイムリミット
    private float time;                         //タイム
    public bool isRewind;

    private void Awake()
    {
        me = this.gameObject;
        me.SetActive(false);
    }

    public void TimeStart()
    {
        me.SetActive(true);
        isRewind = true;
        time = limit;
    }

    public void TimeEnd()
    {
        me.SetActive(false);
        time = 0;
        isRewind = false;
    }

    public void GuageUpdate()
    {
        time -= Time.deltaTime;
        if (time <= 0) TimeEnd();
        guageCircle.fillAmount = time / limit;
        tex.text = (guageCircle.fillAmount * limit).ToString("0.0");
    }

}
