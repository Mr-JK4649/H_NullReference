using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chronos;

[RequireComponent(typeof(Rigidbody))]
public class FallCube : MonoBehaviour
{
    GameObject TimeKeeper;                      //時間制御のｽｸﾘﾌﾟﾄが入ってるオブジェクト
    GlobalClock[] script = new GlobalClock[2];  //クロックを入れる用の配列
    bool IsFall = false;                        //ブロックが落ちたかどうかの判定
    private Rigidbody rb;                       //ブロックのRigidBody
    [SerializeField] private float move;
    private const float gravity = 9.81f;


    public AudioClip sound1;
    AudioSource audioSource;


    void Start()
    {
        TimeKeeper = GameObject.Find("Timekeeper");
        script = TimeKeeper.GetComponents<GlobalClock>();

        audioSource = GetComponent<AudioSource>();

        rb = this.transform.parent.gameObject.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (IsFall)
        {
            move += gravity * Time.deltaTime * script[1].timeScale;
            if (move <= 0) { move = 0; IsFall = false; }

            rb.AddForce(new Vector3(0, -move, 0) * Time.deltaTime, ForceMode.Impulse);
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            IsFall = true;

        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //音(sound1)を鳴らす
            audioSource.PlayOneShot(sound1);

        }

    }
}
