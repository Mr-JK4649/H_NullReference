using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ED_Down : MonoBehaviour
{
    //float count;

    public float z;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //count += Time.deltaTime;
        //if (count >= 19)
        //{
        //}
            transform.Translate(0f, 0f, z);
    }
}
