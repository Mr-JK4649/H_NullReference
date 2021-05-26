using UnityEngine;
using UnityEngine.EventSystems;

public class PauseSystem : MonoBehaviour
{
    //ポーズ画面パネル
    [SerializeField] private GameObject pausePanel;

    //選択ボタン初期位置
    [SerializeField] private GameObject selectButton;

    //音
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
