using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    
	Button tutorial_button;
	Button stage1_button;
	Button stage2_button;
    Button stage3_button;

    void Start()
	{
        // ボタンコンポーネントの取得
        //tutorial_button = GameObject.Find("/Canvas/TutorialButton").GetComponent<Button>();
        //stage1_button = GameObject.Find("/Canvas/Stage1Botton").GetComponent<Button>();
        //stage2_button = GameObject.Find("/Canvas/Stage2Button").GetComponent<Button>();
        stage3_button = GameObject.Find("/Canvas/Stage3Button").GetComponent<Button>();

        // 最初に選択状態にしたいボタンの設定
        //tutorial_button.Select();
        stage3_button.Select();
    }
}
