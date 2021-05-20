using UnityEngine;
using UnityEngine.EventSystems;

public class PauseSystem : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;

    //[SerializeField] private Button firstSelectButton;
    [SerializeField] private GameObject selectButton;

    [SerializeField] private AudioSource _audio;
    [SerializeField] private AudioClip _sound;

    void Update()
    {

        if (Input.GetButtonDown("Cont_Start"))
        {
            Time.timeScale = 1 - Time.timeScale;

            if (Time.timeScale == 0) {
                pausePanel.SetActive(true);
                EventSystem.current.SetSelectedGameObject(selectButton);
                _audio.PlayOneShot(_sound);
            }
            if (Time.timeScale > 0)
            {
                _audio.PlayOneShot(_sound);
            }

        }

        if (Time.timeScale > 0)
        {
            EventSystem.current.SetSelectedGameObject(null);
            pausePanel.SetActive(false);
        }

    }
}
