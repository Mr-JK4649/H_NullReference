using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_gap : MonoBehaviour
{
    [SerializeField] GameObject scen_camera;
    Vector3 init_pos;
    // Start is called before the first frame update
    void Start()
    {
        init_pos = scen_camera.gameObject.transform.localPosition;//カメラの初期座標保存
    }

    // Update is called once per frame

    private void OnTriggerStay(Collider other)
    {
        //シネマシーンカメラの振動でカメラがずれた時に補正させる処理
        if (other.gameObject.tag == "FallObj")
        {
            init_pos.y = 0.00234383f;//カメラ初期ポジションのY座標変換
            scen_camera.transform.localPosition = init_pos;
        }
    }
}
