using UnityEngine;
using Chronos;

public class TheGate : MonoBehaviour
{
    GlobalClock[] gc = new GlobalClock[2];
    [SerializeField] ImageEffect ie;

    private void Start()
    {
        gc = GameObject.Find("Timekeeper").GetComponents<GlobalClock>();
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Gate") {

            if (other.gameObject.name == "StopGate")
            {
                if (gc[1].timeScale != 1)
                {
                    Debug.Log("停止したよ");
                    ie.enabled = false;
                    gc[1].localTimeScale = 1;
                    gc[0].localTimeScale = 1;
                }
                else
                {
                    Debug.Log("停止解除したよ");
                    ie.enabled = true;
                    gc[1].localTimeScale = 0;
                }
            }
            if (other.gameObject.name == "RewindGate") {
                if (gc[1].timeScale != 1)
                {
                    ie.enabled = false;
                    gc[1].localTimeScale = 1;
                    gc[0].localTimeScale = 1;
                }
                else
                {
                    ie.enabled = true;
                    gc[0].localTimeScale = -2;
                }
            }


            other.gameObject.GetComponent<BoxCollider>().enabled = false;
            Destroy(other.gameObject, 0.5f);
        }
    }

}
