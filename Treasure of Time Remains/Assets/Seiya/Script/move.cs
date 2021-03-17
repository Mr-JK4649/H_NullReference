using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Chronos;

public class move : MonoBehaviour
{
    GameObject TimeKeeper;
    GlobalClock[] script = new GlobalClock[2];
    // Start is called before the first frame update
    void Start()
    {
        TimeKeeper = GameObject.Find("Timekeeper");
        script = TimeKeeper.GetComponents<GlobalClock>();
    }

    // Update is called once per frame
    void Update()
    {

        Transform myTransform = this.transform;

        Vector3 pos = myTransform.position;
        pos.z += 0.25f;    

        myTransform.position = pos;  
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("gameover(kari)");
        }
    }
}
