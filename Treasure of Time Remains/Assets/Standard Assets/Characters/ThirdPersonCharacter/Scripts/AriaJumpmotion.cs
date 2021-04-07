using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AriaJumpmotion : MonoBehaviour
{
    public bool aria_check = false;
    // Start is called before the first frame update

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player")){
            aria_check = true;
            Debug.Log("侵入開始");
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            aria_check = false;
            Debug.Log("エリアを抜けました。");
        }
    }
}
