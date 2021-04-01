using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallSound : MonoBehaviour
{
    public AudioClip sound1;
    AudioSource audioSource;

    GameObject[] Fall_Cube_Area; //代入用のゲームオブジェクト配列を用意


    void Start()
    {
        Fall_Cube_Area = GameObject.FindGameObjectsWithTag("Fall");

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {

    }
}
