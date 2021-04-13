using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chronos;

public class RotateAround : MonoBehaviour
{
    public enum RotateAxis
    {
        XAxis,
        YAxis,
        ZAxis
    }

    //　回転軸をどこにするか
    public RotateAxis rotateAxis;
    //　回転スピード
    public float rotateSpeed;
    //　基準点
    public Transform basePosition;

    GameObject TimeKeeper;
    GlobalClock[] script = new GlobalClock[2];

    void Start()
    {
        TimeKeeper = GameObject.Find("Timekeeper");
        script = TimeKeeper.GetComponents<GlobalClock>();
    }

    void Update()
    {
        if (script[0].timeScale == 1 && script[1].localTimeScale == 1)
        {
            Vector3 axis = Vector3.zero;

            if (rotateAxis == RotateAxis.XAxis)
            {
                axis = Vector3.right;
            }
            else if (rotateAxis == RotateAxis.YAxis)
            {
                axis = Vector3.up;
            }
            else if (rotateAxis == RotateAxis.ZAxis)
            {
                axis = Vector3.forward;
            }

            //　回転処理
            float rotation = Time.deltaTime * rotateSpeed;

            transform.RotateAround(basePosition.position, axis, rotation);
        }

    }
}
