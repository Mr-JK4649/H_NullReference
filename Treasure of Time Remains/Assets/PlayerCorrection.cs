using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCorrection : MonoBehaviour
{
    private GameObject me;
    private Rigidbody me_r;

    [SerializeField] private Vector3 accelNum;

    private void Start()
    {
        me = this.gameObject;
        me_r = me.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        me_r.velocity += accelNum;
    }
}
