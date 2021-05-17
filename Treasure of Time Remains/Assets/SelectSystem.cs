using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SelectSystem : MonoBehaviour
{
    [SerializeField] private EventSystem eSys;
    [SerializeField] private Text highScore;
    [SerializeField] private Text Level;
    [SerializeField] private GameObject[] buttons;

    private void FixedUpdate()
    {
        GameObject go = eSys.currentSelectedGameObject.gameObject;

        for (int i = 0; i < buttons.Length - 1; i++)
        {
            if (go == buttons[0])
            {
                Level.text = "★☆☆☆";
            }
            else if (go == buttons[1])
            {
                Level.text = "★★☆☆";
            }
            else if (go == buttons[2])
            {
                Level.text = "★★★☆";
            }
            else if (go == buttons[3])
            {
                Level.text = "★★★★";
            }
            else if (go == buttons[4])
            {
                Level.text = "";
            }
        }

    for (int i = 0; i < buttons.Length - 1; i++) 
            {
                if (go == buttons[i]) highScore.text = "ハイスコア：\n　　　" + ScoreManager.Instance.stage_Highscore[i].ToString();
            }
        if (go == buttons[buttons.Length-1]) highScore.text = "";

        Debug.Log(buttons.Length);
    }
}
