using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ED_ChangeCamera : MonoBehaviour
{
    public GameObject Cam;
    public CameraShake Cam1;
    float count;
    public GameObject Fade;
    public FadeController FadeCon;
    GameObject panel;
    // Start is called before the first frame update
    void Start()
    {

        Application.targetFrameRate = 60;
        Invoke("ChangeCam", 19f);//２0秒後にシーン切りかえ
        Fade = GameObject.Find("FadeCanvas/Panel");
        FadeCon = Fade.GetComponent<FadeController>();
        panel = GameObject.Find("Canvas");
    }

    // Update is called once per frame
    void Update()
    {
        count += Time.deltaTime;
        if (count >= 19.2)
        {
        Cam1.Shake(0.0001f, 0.0001f);
        }
        if (count >= 25)
        {
            FadeCon.enabled = true;
            panel.SetActive(false);
        }
        if (count >= 29)
        {
            SceneManager.LoadScene("Result2");
        }
    }

    void ChangeCam()
    {
        Cam.SetActive(true);
        Cam1.Shake(0.0001f, 0.0001f);

        Debug.Log("ここまではくる");
    }
}
