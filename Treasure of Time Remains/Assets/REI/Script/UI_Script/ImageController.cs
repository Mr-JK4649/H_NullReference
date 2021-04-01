using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class ImageController : MonoBehaviour
{
    [SerializeField] EventSystem eventSystem;

    Image stage_select_image;

    [SerializeField] private Button[] buttons;
    [SerializeField] Sprite[] image;
    [Range(0, 2)]
    public int imgnumber;//画像番号 [0] チュートリアル画像 [1] ステージ1画像 [2] ステージ2画像

    private void Start()
    {
        stage_select_image = GetComponent<Image>();
        imgnumber = 0;
    }

    private void Update()
    {
        GameObject selectedObj = eventSystem.currentSelectedGameObject.gameObject;

        /*追加したやつ*/
        for (int i = 0; i < 2; i++) {
            if (selectedObj == buttons[0])
                stage_select_image.sprite = image[i];
        }
        

        switch (imgnumber)
        {
            case 0:
                stage_select_image.sprite = image[imgnumber];
                break;
            case 1:
                stage_select_image.sprite = image[imgnumber];
                break;
            case 2:
                stage_select_image.sprite = image[imgnumber];
                break;
        }

    }

    
}
