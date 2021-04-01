using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCorrection : MonoBehaviour
{
    private GameObject me;
    private Rigidbody me_r;

    private float oriXpos;

    [SerializeField] private Vector3 accelNum;

    private void Start()
    {
        me = this.gameObject;
        me_r = me.GetComponent<Rigidbody>();

        oriXpos = me.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        me_r.velocity += accelNum;

        float y = me.transform.position.y;
        float z = me.transform.position.z;
        me.transform.position = new Vector3(oriXpos, y, z);
    }
}
