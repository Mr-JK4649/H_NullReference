using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SelectSystem : MonoBehaviour
{
    [SerializeField] private EventSystem eSys;
    [SerializeField] private Text highScore;
    [SerializeField] private GameObject[] buttons;

    private void FixedUpdate()
    {
        GameObject go = eSys.currentSelectedGameObject.gameObject;

        for (int i = 0; i < buttons.Length - 1; i++) {
            if (go == buttons[i]) highScore.text = "ハイスコア：\n　　　" + ScoreManager.Instance.stage_Highscore[i].ToString();
        }
        if (go == buttons[buttons.Length-1]) highScore.text = "";

        Debug.Log(buttons.Length);
    }
}
