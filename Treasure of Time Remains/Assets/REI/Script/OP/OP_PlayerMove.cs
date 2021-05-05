using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OP_PlayerMove : MonoBehaviour
{
    float count;
    public GameObject Mojiban;
    public GameObject cam;
    public AudioClip sound1;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        //GameObject Mojiban = this.transform.Find("ClockCanvas").gameObject;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        count += Time.deltaTime;
        if (count <= 7)
        {
            transform.Translate(0f, 0f, 0.005f);

        }
        else if (count > 11.5)
        {
            Mojiban.SetActive(true);
            audioSource.PlayOneShot(sound1);
            cam.SetActive(true);
        }
        else
        {
            cam.SetActive(false);
        }
    }
}
