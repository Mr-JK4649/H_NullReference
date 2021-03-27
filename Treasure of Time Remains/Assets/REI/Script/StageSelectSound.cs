using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelectSound : MonoBehaviour
{

    public AudioClip MenuMove;
    public AudioClip MenuOK;
    AudioSource audioSource;

    void Start()
    {
        //Componentを取得
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {

        // 左右
        if (Input.GetButtonDown("Horizontal"))
        {
            //音(MenuMove)を鳴らす
            audioSource.PlayOneShot(MenuMove);
        }
        if (Input.GetButtonDown("Jump"))
        {
            //音(MenuMove)を鳴らす
            audioSource.PlayOneShot(MenuOK);
        }

    }
}
