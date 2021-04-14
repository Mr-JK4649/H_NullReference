using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    private GameObject ParentPanel;
    private GameObject ChildPanel;
    private int count;
    private int MaxCount;

    public Text timerText;

    public float totalTime;
    int seconds;

    // Use this for initialization
    void Start()
    {
        totalTime = 5;
        timerText = this.GetComponent<Text>(); ;
        //TextPanel= this.transform.parent.gameObject;
        ParentPanel = this.transform.gameObject;//このスクリプトをアタッチしているオブジェクトの取得
        ChildPanel = ParentPanel.transform.GetChild(0).gameObject;//このスクリプトをアタッチしているオブジェクトの子オブジェクトの取得
        count = 0;
        ChildPanel.SetActive(false);//子オブジェクトを非表示
        MaxCount = 300;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0 && count <= MaxCount)
        {
            //Time.timeScale = 1;
            count++;
        }
        if (count >= MaxCount && Time.timeScale == 0)
        {
            Time.timeScale = 1;
            count = 0;
        }

        totalTime -= Time.deltaTime;
        seconds = (int)totalTime;
        timerText.text = seconds.ToString();

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
