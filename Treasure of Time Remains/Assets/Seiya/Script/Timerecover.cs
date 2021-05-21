using UnityEngine;
using System;

public class Timerecover : MonoBehaviour
{
    [SerializeField]
    GameObject objeffect;

    Sample effect;

    [SerializeField] private TimeGauge timeGauge;
    [SerializeField] private ClockGauge clockgauge;

    [SerializeField, Tooltip("オーブの点数を表示するオブジェクト")]
    private Transform p_T_Parent;

    [SerializeField, Tooltip("点数表示テキストのprefab")]
    private GameObject p_Text;

    [NonSerialized] public bool isDebug = false;
    [NonSerialized,Range(0,10)] public float range;

    private AudioSource _audioSource;
    [SerializeField] private AudioClip _orbSound;

    private void Start()
    {
        effect = objeffect.GetComponent<Sample>();
        _audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Recover")
        {
            _audioSource.PlayOneShot(_orbSound);
            effect.effectStatus = true;
            ScoreManager.Instance.orb += 1;
            Instantiate(p_Text, other.transform.position, Quaternion.identity, p_T_Parent);
            if (isDebug)
            {
                Vector3 add = new Vector3(0, 1, range);
                Instantiate(other.gameObject, transform.position + add, Quaternion.identity);
            }
            Destroy(other.gameObject);
        }
    }


}
