using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OPSceneMovie : MonoBehaviour
{
    // 長押しフレーム数
    [SerializeField] public int presskeyFrames = 0;
    // 長押し判定の閾値（フレーム数）
    private int thresholdLong = 60;
    // 軽く押した判定の閾値（フレーム数）
    private int thresholdShort = 30;
    private int flg = 0;
    private float count;
    public GameObject fade;

    // Use this for initialization
    void Start()
    {
        //Application.targetFrameRate = 60;
        Invoke("ChangeScene", 20f);//２0秒後にシーン切りかえ

        Application.targetFrameRate = 60;
    }
    private void Update()
    {
        //ボタンを押している間加算続ける
        presskeyFrames += (Input.GetButton("Action2")) ? 1 : 0;
        //ボタンを離したときに値をリセットする
        if (Input.GetButtonUp("Action2")) presskeyFrames = 0;

        //決められたフレーム数押したとき
        if (thresholdLong <= presskeyFrames)flg = 1;

        if (flg == 1)
        {
            fade.SetActive(true);
            presskeyFrames = thresholdLong;
            count += Time.deltaTime;
        }

        if (count > 2) ChangeScene();
    }

    void ChangeScene()
    {
        SceneManager.LoadScene("Title");
    }
}