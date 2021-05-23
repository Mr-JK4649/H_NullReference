using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall_Obj_AudioSauce : MonoBehaviour
{
    AudioSource myAudio;

    private void Start()
    {
        myAudio = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "FallObj")
        {
            myAudio.Play();
        }
    }
}
