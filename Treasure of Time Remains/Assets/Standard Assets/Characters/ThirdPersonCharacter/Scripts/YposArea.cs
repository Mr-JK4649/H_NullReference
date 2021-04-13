using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YposArea: MonoBehaviour
{
    public bool aria_check = false;
    // Start is called before the first frame update
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player")){
            aria_check = true;
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            aria_check = false;
        }
    }
}
