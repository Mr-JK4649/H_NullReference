using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //パネルのイメージを操作するのに必要

public class ImageMove : MonoBehaviour
{
    public RectTransform rogo;
    float x;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public int rogoMove()
    {
        if (x++ < 115)
        {
            rogo.position += new Vector3(10, 0, 0);
            if (Input.GetButtonDown("Jump")) x = 116;
            return 0;
        }
        else
        {
            rogo.position = new Vector3(720, 529, 0);
            return 1;
        }

    }
}
