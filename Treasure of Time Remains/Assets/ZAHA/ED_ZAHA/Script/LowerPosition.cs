using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowerPosition : MonoBehaviour
{
    [SerializeField] float time;
    Transform myposition;
    float lower_posy;

    [SerializeField] AnimationCurve lower_valu;
    float lower_valu_time;
    // Start is called before the first frame update
    void Start()
    {
        myposition = this.transform;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Invoke("Lower", time);

        if(myposition.localPosition.y <= -14f)
        {
            myposition.localPosition = new Vector3(myposition.localPosition.x,-14f,myposition.localPosition.z);
            lower_valu_time = 0;
        }

        lower_posy = lower_valu.Evaluate(lower_valu_time);
    }

    void Lower()
    {
        lower_valu_time += Time.deltaTime;

        myposition.Translate(0f,-lower_posy,0f);
    }
}
