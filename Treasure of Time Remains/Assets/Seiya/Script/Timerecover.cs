using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timerecover : MonoBehaviour
{
    public TimeGauge TimeS; //時間停止用
    public TimeGauge TimeR; //時間逆行用

    private const float Recovery = 0.2f;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Recover")
        {
            TimeS.Recover(Recovery);
            Destroy(other.gameObject);
        }
    }
}
