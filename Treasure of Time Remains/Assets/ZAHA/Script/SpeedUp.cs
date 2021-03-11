using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour
{
    [SerializeField]
    float speed = 1;

    [SerializeField]
    GameObject player;


    Vector3 pos = new Vector3(3,3,3);
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //前移動
        player.transform.position += transform.forward * speed * Time.deltaTime;
    }

}
