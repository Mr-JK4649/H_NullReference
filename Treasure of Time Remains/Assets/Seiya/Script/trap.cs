using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class trap : MonoBehaviour
{
    public GameObject particleObject;//パーティクル格納
    private GameObject rp;//親オブジェクトの座標
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rp = transform.parent.gameObject;

        rb = this.transform.parent.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            rp.SetActive(true);
            //Instantiate(particleObject, this.transform.position, Quaternion.identity);
            //Quaternion.Euler(0f, 0f, 1.0f)
            GameObject oho = Instantiate(particleObject, rp.transform.position, Quaternion.Euler(90.0f, 0.0f, 90.0f));
            Destroy(oho, 2f);
        }

    }
}
