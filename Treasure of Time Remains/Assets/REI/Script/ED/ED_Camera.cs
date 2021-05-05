using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ED_Camera : MonoBehaviour
{
    public CameraShake shake;
    // Start is called before the first frame update
    void Start()
    {

        Invoke("PlayerOn", 3f);//２0秒後にシーン切りかえ
    }

    // Update is called once per frame
    void Update()
    {
        //カメラの振動
        shake.Shake(0.0001f, 0.0001f);
    }

    void PlayerOn()
    {
        gameObject.SetActive(true);
    }
}
