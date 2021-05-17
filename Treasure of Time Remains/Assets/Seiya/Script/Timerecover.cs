using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timerecover : MonoBehaviour
{
    [SerializeField] private TimeGauge timeGauge;
    [SerializeField] private ClockGauge clockgauge;

    [SerializeField, Tooltip("オーブの点数を表示するオブジェクト")]
    private Transform p_T_Parent;

    [SerializeField, Tooltip("点数表示テキストのprefab")]
    private GameObject p_Text;

    private const float Recovery = 0.2f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Recover")
        {
            clockgauge.Recover(Recovery);
            timeGauge.Recover(Recovery);
            ScoreManager.Instance.orb += 1;
            Instantiate(p_Text, other.transform.position, Quaternion.identity, p_T_Parent);
            Destroy(other.gameObject);
        }
    }

}
