using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock_UI_Distance : MonoBehaviour
{
    public Transform UI_clock;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(UI_clock.transform.position, transform.position);
        Debug.Log(distance);
    }
}
