using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OP_Orb_Move : MonoBehaviour
{
    float count;
    public AudioClip sound1;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {

        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(sound1);
    }

    // Update is called once per frame
    void Update()
    {
        count += Time.deltaTime;
        if (count >= 8.3 && count <= 10)
        {
            transform.Translate(0f, 0f, 0.004f);

        }
        else if (count > 10)
        {
            gameObject.SetActive(false);
        }
    }
}
