using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SelectSystem : MonoBehaviour
{
    [SerializeField] private EventSystem eSys;
    [SerializeField] private Text highScore;
    [SerializeField] private Text Level;
    [SerializeField] private GameObject[] buttons;
    [SerializeField] private GameObject gameEndMenuObj;
    [SerializeField] private GameObject firstSelectButtonEnd;

    public bool gameEndMenu = false;
    private Button[] button = new Button[5];
    private GameObject oldSelectedButton;

    private void Start()
    {
        gameEndMenuObj.SetActive(false);

        for (int i = 0; i < buttons.Length; i++) {
            button[i] = buttons[i].GetComponent<Button>();

        }
    }

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


        //ゲーム終了メニュー
        if (Input.GetButtonDown("Cont_Start")) {
            gameEndMenu = !gameEndMenu;

            //ゲーム終了メニューを開いてる間、後ろのボタンの遷移昨日をなくす。
            if (gameEndMenu)
            {
                oldSelectedButton = eSys.currentSelectedGameObject;
                ButtonNavChange(true);
                EventSystem.current.SetSelectedGameObject(firstSelectButtonEnd);
            }
            else
            {
                ButtonNavChange(false);
                EventSystem.current.SetSelectedGameObject(oldSelectedButton);
            }

        }
        //if (Input.GetButtonUp("Cont_Start")) flg = true;
    }

    private void ButtonNavChange(bool t_f) {
        for (int i = 0; i < buttons.Length; i++)
        {
            var nav = button[i].navigation;
            if (t_f) nav.mode = Navigation.Mode.None;
            else nav.mode = Navigation.Mode.Vertical;
            button[i].navigation = nav;
        }

        gameEndMenuObj.SetActive(t_f);
    }

    public void GameEnd(bool y_n) {

        if (y_n)//終了する
        {
            Application.Quit();
        }
        else { //終了しない
            ButtonNavChange(false);
        }
    }
}
