using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OPSceneMovie : MonoBehaviour
{


    // Use this for initialization
    void Start()
    {
        //Application.targetFrameRate = 60;
        Invoke("ChangeScene", 20f);//２0秒後にシーン切りかえ

        Application.targetFrameRate = 60;
    }

    void ChangeScene()
    {
        SceneManager.LoadScene("StageSelect");
    }
}