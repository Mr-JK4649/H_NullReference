using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //パネルのイメージを操作するのに必要

public class ImageMove : MonoBehaviour
{
    public RectTransform a;
    float x;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (x < 1150)
        {
            x += 10;
            a.position += new Vector3(10, 0, 0);
        }
    }
}
