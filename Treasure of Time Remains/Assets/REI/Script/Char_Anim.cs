using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char_Anim : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void select_button()
    {
        this.gameObject.transform.localScale = new Vector3(1.5f, 1.5f, 0);
    }
}
