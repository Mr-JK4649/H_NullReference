using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseSystem : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;

    private void Start()
    {
        pausePanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetButtonDown("Cont_Start"))
            Time.timeScale = 1 - Time.timeScale;

        if(Time.timeScale > 0) pausePanel.SetActive(false);
        if(Time.timeScale == 0) pausePanel.SetActive(true);
    }
}
