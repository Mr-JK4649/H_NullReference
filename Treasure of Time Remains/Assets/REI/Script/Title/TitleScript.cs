using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScript : MonoBehaviour
{
    float count;
    float flg = 0;
    public GameObject fade;

    public AudioClip sound1;
    AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
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
