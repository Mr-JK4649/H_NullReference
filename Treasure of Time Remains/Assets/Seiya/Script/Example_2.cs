using UnityEngine;

public class Example_2 : MonoBehaviour
{
    public CameraShake shake;
    public AudioClip Hari_SE;
    AudioSource audioSource;
    private bool Stay = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();//れいが追加
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Hari" && Stay == false)
        {
            shake.Shake(0.35f, 0.35f);
            audioSource.PlayOneShot(Hari_SE);//落下音を鳴らす
            Stay = true;
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Hari")
        {
            Debug.Log("ぬけました");
            Stay = false;
        }

    }
}