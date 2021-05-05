using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ED_ChangeCamera : MonoBehaviour
{
    public GameObject Cam;
    // Start is called before the first frame update
    void Start()
    {

        Invoke("ChangeCam", 19f);//２0秒後にシーン切りかえ
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeCam()
    {
        Cam.SetActive(true);
    }
}
