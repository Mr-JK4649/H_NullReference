using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scale : MonoBehaviour
{
    Transform mytransform;
    [SerializeField]float time;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Invoke("Scalesize", time);
        mytransform = this.transform;

        if (mytransform.localScale.y <= 1f)
        {
            Destroy(this.gameObject);
        }
    }

    void Scalesize()
    {
        mytransform.localScale -= new Vector3(0f,0.01f,0f);
    }
}
