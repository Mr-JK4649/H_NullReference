using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OPSceneMovie : MonoBehaviour
{


    // Use this for initialization
    void Start()
    {

        Invoke("ChangeScene", 100f);//２秒後にシーン切りかえ
    }

    void ChangeScene()
    {
        SceneManager.LoadScene("StageSelect");
    }
}