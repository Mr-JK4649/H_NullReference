using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OP_Orb_Move : MonoBehaviour
{
    float count;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        count += Time.deltaTime;
        if (count >= 8.3 && count <= 11)
        {
            transform.Translate(0f, 0f, 0.0008f);

        }
        else if (count > 10.5)
        {
            gameObject.SetActive(false);
        }
    }
}
