using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OP_PlayerMove : MonoBehaviour
{
    float count;
    public GameObject Mojiban;
    public GameObject cam;

    // Start is called before the first frame update
    void Start()
    {
        //GameObject Mojiban = this.transform.Find("ClockCanvas").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        count += Time.deltaTime;
        if (count <= 7)
        {
            transform.Translate(0f, 0f, 0.0015f);

        }
        else if (count > 11.5)
        {
            Mojiban.SetActive(true);
            cam.SetActive(true);
        }
        else
        {
            cam.SetActive(false);
        }
    }
}
