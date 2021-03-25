using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doa : MonoBehaviour
{
    //力
    Vector3 force = new Vector3(10f,0f,0f);
    //オブジェクト位置
    Vector3 pos;
    //物理
    Rigidbody rb;

    //ドアフラグ
    bool doaflg = false;

    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
        //Rigidbody生成
        rb = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            doaflg = true;
            rb.AddForce(force,ForceMode.Impulse);
            Debug.Log("Hit");
        }
    }
}

