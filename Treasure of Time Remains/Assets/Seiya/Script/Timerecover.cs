using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timerecover : MonoBehaviour
{
    [SerializeField] private TimeGauge timeGauge;
    [SerializeField] private ClockGauge clockgauge;

    private const float Recovery = 0.2f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Recover")
        {
            clockgauge.Recover(Recovery);
            timeGauge.Recover(Recovery);
            ScoreManager.Instance.orb += 1;
            Destroy(other.gameObject);
        }
    }

}
