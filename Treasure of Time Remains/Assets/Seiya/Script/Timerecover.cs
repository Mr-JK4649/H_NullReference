using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timerecover : MonoBehaviour
{
    [SerializeField] private TimeGauge timeGauge;
    [SerializeField] private int score;

    private const float Recovery = 0.2f;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Recover")
        {
            timeGauge.Recover(Recovery);
            ScoreManager.Instance.score += score;
            Destroy(other.gameObject);
        }
    }

}
