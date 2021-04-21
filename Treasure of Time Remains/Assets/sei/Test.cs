using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    private GameObject ParentPanel;
    private GameObject ChildPanel;
    private int count;//text表示の秒数
    private int MaxCount;//text表示の最大秒数
    private int MinCount;//text表示の最低秒数
    private Text timerText;

    private float totalTime;
    private int seconds;//秒数表示のための変数

    private GameObject Child;

    // Use this for initialization
    void Start()
    {
        //TimeTextプレハブをGameObject型で取得
        //GameObject obj = (GameObject)Resources.Load("TimeText");
        // TimeTextプレハブを元に、インスタンスを生成、
        //GameObject TimeText = (GameObject)Instantiate(obj, new Vector3(0f, 0f, 0f), Quaternion.identity);
        ////GameObject objj = (GameObject)Instantiate(obj);
        
        //GameObject TimeText = Instantiate(obj,ChildPanel.transform);

        totalTime = 5;
        //timerText = GameObject.Find("TimeText").GetComponent<Text>();
        //TextPanel= this.transform.parent.gameObject;
        
        ParentPanel = this.transform.gameObject;//このスクリプトをアタッチしているオブジェクトの取得
        ChildPanel = ParentPanel.transform.GetChild(0).gameObject;//このスクリプトをアタッチしているオブジェクトの子オブジェクトの取得

        //gameObject.transform.Find("TimeText").transform.SetParent(ChildPanel.transform, false);

        //TimeText.transform.parent = ChildPanel.transform;//TimeTextをChildPanelの親に設定する

        //TimeTextプレハブをGameObject型で取得
        GameObject obj = (GameObject)Resources.Load("TimeText");
        // TimeTextプレハブを元に、インスタンスを生成
        GameObject TimeText = Instantiate(obj, ChildPanel.transform);
        //TimeTextのオブジェクトに名づけ
        TimeText.name = "TimeText";

        timerText = ChildPanel.transform.Find("TimeText").GetComponent<Text>();//時間を表示するためのオブジェクトを読み込む

        //count = 0;
        ChildPanel.SetActive(false);//子オブジェクトを非表示
        MaxCount = 300;
        MinCount = 0;
        count = MaxCount;
        //ChildPanel.gameObject.transform.parent = obj.gameObject.transform;

        Vector3 tmp = GameObject.Find("Ground").transform.position;//groundの座標取得してvectorに代入
        this.gameObject.transform.position = new Vector3(tmp.x, tmp.y+8, tmp.z);//groundの座標取得してコライダーに代入
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0 && count > MinCount)
        {
            count--;
            seconds = (int)count / 60;
        }
        if (Time.timeScale == 0 && count <= MinCount)
        {
            Time.timeScale = 1;
            count = MaxCount;
        }

        timerText.text = seconds.ToString();
        //if (Time.timeScale == 0 && count <= MaxCount)
        //{
        //    //Time.timeScale = 1;
        //    count++;
        //}
        //if (count >= MaxCount && Time.timeScale == 0)
        //{
        //    Time.timeScale = 1;
        //    count = 0;
        //}

        //if (Time.timeScale == 0 && totalTime > 0)
        //{
        //    totalTime -= Time.deltaTime;
        //    seconds = (int)totalTime;
        //    //timerText.text = seconds.ToString();
        //}
        //if (Time.timeScale == 0 && totalTime == 0)
        //{
        //    Time.timeScale = 1;
        //    totalTime = 5;
        //}


        //totalTime -= Time.deltaTime;
        //seconds = (int)totalTime;
        //timerText.text = seconds.ToString();

        //if (Input.GetButtonDown("Cont_Start"))
        //{
        //    Time.timeScale = 1 - Time.timeScale;
        //    if (Time.timeScale == 0)
        //    {
        //        //pausePanel.SetActive(true);
        //        //button[0].Select();
        //    }
        //}

        //if (Time.timeScale > 0) pausePanel.SetActive(false);
    }

    //private void OnTriggerEnter(Collider collider)
    //{
    //    if (collider.gameObject.tag == "Player")
    //    {
    //        TextPanel.SetActive(true);
    //        Time.timeScale = 0;

    //    }
    //}

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            ChildPanel.SetActive(true);
            Time.timeScale = 0;
            //Time.timeScale = 1;
        }
        //if (collider.gameObject.tag == "Player")
        //{
        //    TextPanel.SetActive(false);
        //}
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            ChildPanel.SetActive(false);
            ParentPanel.SetActive(false);
        }
    }

}
