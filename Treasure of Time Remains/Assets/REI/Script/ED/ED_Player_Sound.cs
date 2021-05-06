using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ED_Player_Sound : MonoBehaviour
{
    public AudioClip sound1;
    public AudioClip sound2;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Invoke("Sound",1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Sound()
    {
        audioSource.PlayOneShot(sound1);
        audioSource.PlayOneShot(sound2);

    }
}
