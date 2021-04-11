using UnityEngine;

public class Example : MonoBehaviour
{
    public CameraShake shake;
    public AudioClip Fall_SE;
    AudioSource audioSource;
    private bool Stay = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();//れいが追加
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Fall" && Stay == false)
        {
            shake.Shake(0.35f, 0.35f);
            audioSource.PlayOneShot(Fall_SE);//落下音を鳴らす
            Stay = true;
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Fall")
        {
            Debug.Log("ぬけました");
            Stay = false;
        }

    }
}