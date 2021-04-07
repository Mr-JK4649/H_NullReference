using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift : MonoBehaviour
{

    private GameObject parent;

    //private void OnTriggerEnter(Collider other)
    //{
    //    入ってきたオブジェクトを格納
    //    player = other.gameObject;

    //    元のオブジェクトを非アクティブ化
    //    player.SetActive(false);

    //    新しいオブジェクトを作る


    //}

    private void Start()
    {
        parent = this.transform.parent.gameObject;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Lift")
        {
            transform.SetParent(col.transform.parent);
        }
    }


    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Lift")
        {
            transform.SetParent(null);
            transform.SetParent(parent.transform);
        }
    }
}
