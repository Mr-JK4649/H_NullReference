using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageImageChange : MonoBehaviour
{
    [SerializeField] private Image image;

    public void ChangeImage(Sprite s) {
        image.sprite = s;
    }
}
