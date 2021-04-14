using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test2 : MonoBehaviour
{
    [SerializeField] public List<GameObject> TutorialList = new List<GameObject>();//リスト生成
    private int ListNumber;//リストの要素数

    void Start()
    {
        ListNumber = 0;//リストの要素数を初期化

        foreach (Transform child in transform)
        {
            TutorialList.Add(child.transform.gameObject);//リストに子オブジェクト入れる
            child.gameObject.AddComponent<Test>();//子オブジェクトにtestスクリプトを入れる
            child.gameObject.SetActive(false);//子オブジェクトを非表示にする
        }

        TutorialList[0].SetActive(true);//最初の子オブジェクトのアクティブをtrue
    }

    private void Update()
    {
        if (!TutorialList[ListNumber].activeSelf/* && !TutorialList[ListNumber + 1].activeSelf*/)
        {
            TutorialList[ListNumber + 1].SetActive(true);//次の子要素のアクティブをtrueにする
            ListNumber++;//リストの要素数を加算
        }
    }
}