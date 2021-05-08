using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class test3 : MonoBehaviour
{
    [SerializeField] GameObject TextPanel;
    private int count;//text表示の秒数
    private int MaxCount;//text表示の最大秒数
    private int MinCount;//text表示の最低秒数
    private int seconds;//秒数表示のための変数
    private Text timerText;//秒数を表示するためのtext

    private bool TimeFlg;
    // Use this for initialization
    void Start()
    {
        //テキストを表示する最大秒数を代入
        MaxCount = 300;
        //テキストを表示する最低秒数を代入
        MinCount = 0;
        //テキストを表示する秒数をカウント
        count = MaxCount;
        //textオブジェクトを非表示
        TextPanel.SetActive(false);
        //
        TimeFlg = false;

        ////TimeTextプレハブをGameObject型で取得
        //GameObject obj = (GameObject)Resources.Load("TimeText");
        //// TimeTextプレハブを元に、インスタンスを生成
        //GameObject TimeText = Instantiate(obj, TextPanel.transform);
        ////TimeTextのオブジェクトに名づけ
        //TimeText.name = "TimeText";
        ////時間を表示するためのオブジェクトを読み込む
        //timerText = TextPanel.transform.Find("TimeText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (/*Time.timeScale == 0 &&*/ count > MinCount && TimeFlg)
        {
            count--;
            //seconds = (int)count / 60;
        }
        if (/*Time.timeScale == 0 &&*/ count <= MinCount && TimeFlg)
        {
            //Time.timeScale = 1;
            count = MaxCount;
            TextPanel.SetActive(false);
            TimeFlg = false;
        }

        //timerText.text = seconds.ToString();
    }

    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            TextPanel.SetActive(true);
            TimeFlg = true;
            //Time.timeScale = 0;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            //TextPanel.SetActive(false);
        }
    }
}