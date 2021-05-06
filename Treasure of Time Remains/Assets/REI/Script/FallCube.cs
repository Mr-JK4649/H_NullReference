using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chronos;

[RequireComponent(typeof(Rigidbody))]
public class FallCube : MonoBehaviour
{
    GameObject TimeKeeper;                      //時間制御のｽｸﾘﾌﾟﾄが入ってるオブジェクト
    GlobalClock[] script = new GlobalClock[2];  //クロックを入れる用の配列
    public bool IsFall = false;                        //ブロックが落ちたかどうかの判定
    private Rigidbody rb;                       //ブロックのRigidBody
    [SerializeField] private float move;
    private const float gravity = 9.81f;

    public GameObject particleObject;//パーティクル格納
    private GameObject rp;//親オブジェクトの座標


    void Start()
    {
        TimeKeeper = GameObject.Find("Timekeeper");
        script = TimeKeeper.GetComponents<GlobalClock>();
        rp = transform.parent.gameObject;

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
            //Instantiate(particleObject, this.transform.position, Quaternion.identity);
            //Quaternion.Euler(0f, 0f, 1.0f)
            GameObject oho = Instantiate(particleObject, rp.transform.position, Quaternion.Euler(90.0f, 0.0f, 90.0f));
            Destroy(oho, 2f);
        }

    }
}
