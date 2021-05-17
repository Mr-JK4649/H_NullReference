using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ED_Camera : MonoBehaviour
{
    public CameraShake Cam1;
    // Start is called before the first frame update
    void Start()
    {

        Invoke("PlayerOn", 3f);//２0秒後にシーン切りかえ
    }

    // Update is called once per frame
    void Update()
    {
        //カメラの振動
        Cam1.Shake(0.0003f, 0.0003f);
    }

    void PlayerOn()
    {
        gameObject.SetActive(true);
    }
}
