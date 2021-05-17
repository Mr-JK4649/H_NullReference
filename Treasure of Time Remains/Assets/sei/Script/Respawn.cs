using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private GameObject Respawn1;
    //[SerializeField] private GameObject Respawn2;
    //[SerializeField] private GameObject Respawn3;
    private GameObject Block;
    private FallCube BlockCS;

    private Vector3 RespawnPoint1;
    //private Vector3 RespawnPoint2;
    //private Vector3 RespawnPoint3;
    private Vector3 BlockPoint;

    // Start is called before the first frame update
    void Start()
    {
        RespawnPoint1 = Respawn1.transform.position;
        //RespawnPoint2 = Respawn2.transform.position;
        //RespawnPoint3 = Respawn3.transform.position;
        Block = GameObject.Find("FallCube13");
        BlockPoint = Block.transform.position;
        BlockCS = Block.transform.GetChild(0).GetComponent<FallCube>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        //if(gameObject.tag== "Respawn") {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.position = RespawnPoint1;
            if(this.gameObject.name== "Resuscitation2")
            {
                Block.transform.position = BlockPoint;
                BlockCS.IsFall = false;
            }
        }
    }
}
