using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall_Obj : MonoBehaviour
{
    [SerializeField] float time;
    [SerializeField] GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    private void FixedUpdate()
    {
        Invoke("Fall", time);
    }
    void Fall()
    {
        obj.SetActive(true);
    }

}
