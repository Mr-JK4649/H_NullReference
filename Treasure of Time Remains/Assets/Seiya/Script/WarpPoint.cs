using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WarpPoint : MonoBehaviour
{
    
    //public Vector3 pos;

    public TimeControl time;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Death")
        {

            SceneManager.LoadScene("gameover(kari)");
        }
    }
}