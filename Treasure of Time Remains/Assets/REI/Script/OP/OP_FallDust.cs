using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OP_FallDust : MonoBehaviour
{
    float count;
    public GameObject particleObject;
    public CameraShake shake;
    public AudioClip sound1;
    AudioSource audioSource;

    private void Start()
    {

        audioSource = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        count += Time.deltaTime;
        if (count > 15 && count < 15.01)
        {
            audioSource.PlayOneShot(sound1);
            Instantiate(particleObject, this.transform.position, Quaternion.identity); //パーティクル用ゲームオブジェクト生成
        }
        if (count > 15)
        {
            shake.Shake(0.0002f, 0.0002f);
        }
    }

}
