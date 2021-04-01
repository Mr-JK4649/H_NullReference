using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseSystem : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;

    [SerializeField] private Button[] button;

    void Update()
    {
        if (Input.GetButtonDown("Cont_Start"))
        {
            Time.timeScale = 1 - Time.timeScale;
            if (Time.timeScale == 0) {
                pausePanel.SetActive(true);
                button[0].Select();
            }
        }

        if (Time.timeScale > 0) pausePanel.SetActive(false);
    }
}
