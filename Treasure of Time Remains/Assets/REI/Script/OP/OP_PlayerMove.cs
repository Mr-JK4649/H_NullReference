using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OP_PlayerMove : MonoBehaviour
{
    float count;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        count += Time.deltaTime;
        if (count <= 7)
        {
        transform.Translate(0f, 0f, 0.001f);

        }
    }
}
