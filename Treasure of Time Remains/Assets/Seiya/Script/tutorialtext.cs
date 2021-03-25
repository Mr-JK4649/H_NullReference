using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tutorialtext : MonoBehaviour
{
    [SerializeField] GameObject TextPanel;

    // Use this for initialization
    void Start()
    {

        TextPanel.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            TextPanel.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            TextPanel.SetActive(false);
        }
    }

}
