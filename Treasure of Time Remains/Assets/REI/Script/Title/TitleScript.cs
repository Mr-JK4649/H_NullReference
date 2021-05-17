using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScript : MonoBehaviour
{
    float count;
    float flg = -1;
    public bool rogoflg = false;
    public GameObject fade;

    public AudioClip sound1;
    AudioSource audioSource;

    public GameObject Abutton;

    ImageMove IM;
    GameObject titleimage;


    // Start is called before the first frame update
    void Start()
    {
        titleimage = GameObject.Find("Canvas/TitleImage");
        IM = titleimage.GetComponent<ImageMove>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if(IM.rogoMove() == 1 && !Input.GetButton("Jump") && flg == -1)
        {
            flg = 0;
            Abutton.SetActive(true);
        }



        //タイトルロゴが最終位置に来ている時
        if (flg == 0 && Input.GetButtonDown("Jump"))
        {
            flg = 1;
            fade.SetActive(true);
            audioSource.PlayOneShot(sound1);
        }

        if (flg == 1)
        {
            count += Time.deltaTime;
        }

        if (count >= 2) SceneMove();

    }
    void SceneMove()
    {
        SceneManager.LoadScene("StageSelect");
    }
}
