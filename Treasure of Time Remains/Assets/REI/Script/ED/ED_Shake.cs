using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ED_Shake : MonoBehaviour
{
    public CameraShake shake;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        shake.Shake(0.01f, 0.01f);
    }
}
