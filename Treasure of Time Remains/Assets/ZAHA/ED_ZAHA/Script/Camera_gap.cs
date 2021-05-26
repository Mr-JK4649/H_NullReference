using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Camera : MonoBehaviour
{
    GameObject scen_camera;
    Vector3 init_pos;
    // Start is called before the first frame update
    void Start()
    {
        init_pos = scen_camera.gameObject.transform.position;//カメラの初期座標保存
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        //scenで落ちてきたオブジェクトのタグがFallObjだったら
        if(other.gameObject.tag == "FallObj")
        {
            scen_camera.transform.position = init_pos;
        }
    }
}
