using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //パネルのイメージを操作するのに必要

public class ImageMove : MonoBehaviour
{
    public RectTransform rogo;
    float x;
    TitleScript TS;
    GameObject TM;
    // Start is called before the first frame update
    void Start()
    {
        TM = GameObject.Find("TitleManager");
        TS = TM.GetComponent<TitleScript>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void rogoMove()
    {
        if (TS.rogoflg == false && x < 1150)
        {
            x += 10;
            rogo.position += new Vector3(10, 0, 0);
        }
        else
        {
            TS.rogoflg = true;
            rogo.position = new Vector3(0, 124, 0);
        }
    }
}
