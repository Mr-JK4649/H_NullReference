using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Vibration : MonoBehaviour
{
    //public GameObject Obj;
    public float duration;
    public float magnitude;

    private void Update()
    {
        Shake();
    }
    void Shake()
    {
        var pos = this.transform.localPosition;

        var elapsed = 0f;

        while (elapsed < duration)
        {
            var x = pos.x + Random.Range(-1f, 1f) * magnitude;
            var y = pos.y + Random.Range(-1f, 1f) * magnitude;

            this.transform.localPosition = new Vector3(x, y, pos.z);

            elapsed += Time.deltaTime;

        }

        this.transform.localPosition = pos;
    }

}