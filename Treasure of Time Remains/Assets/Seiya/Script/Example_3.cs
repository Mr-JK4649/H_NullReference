using UnityEngine;

public class Example_3 : MonoBehaviour
{
    public CameraShake shake;
    public AudioClip S_Hari_SE;
    AudioSource audioSource;
    private bool Stay = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();//れいが追加
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "S_Hari" && Stay == false)
        {
            shake.Shake(0.35f, 0.35f);
            audioSource.PlayOneShot(S_Hari_SE);//落下音を鳴らす
            Stay = true;
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "S_Hari")
        {
            Debug.Log("ぬけました");
            Stay = false;
        }

    }
}