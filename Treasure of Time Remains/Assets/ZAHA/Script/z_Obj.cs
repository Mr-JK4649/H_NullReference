using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class z_Obj : MonoBehaviour
{
    [SerializeField]
    GameObject obj;
    [SerializeField]
    float objMax = 100;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < objMax; i++)
        {
            Instantiate(obj, new Vector3(-2f, 0.5f, (-17f + (i * 3))), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
