using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OP_PlaySound : MonoBehaviour
{

    public AudioClip sound1;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        audioSource.PlayOneShot(sound1);
    }
}
