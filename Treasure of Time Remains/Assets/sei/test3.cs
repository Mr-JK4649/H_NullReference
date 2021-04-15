using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test3 : MonoBehaviour
{

    // 初期化
    void Start()
    {
        GameObject obj = (GameObject)Resources.Load("Cube");

        // プレハブを元にオブジェクトを生成する
        GameObject instance = (GameObject)Instantiate(obj,
                                                      new Vector3(5.0f, 0.0f, 0.0f),
                                                      Quaternion.identity);
    }
}