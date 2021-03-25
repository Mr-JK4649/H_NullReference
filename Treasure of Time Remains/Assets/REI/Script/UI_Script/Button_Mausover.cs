using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Button_Mausover : MonoBehaviour
{

    GameObject imgobj;
    ImageController imagecontroller;

    private void Start()
    {
        imgobj = GameObject.Find("Stage_select_Image");
        imagecontroller = imgobj.GetComponent<ImageController>();
    }

    public void ImageTutorial()
    {
        imagecontroller.imgnumber = 0;
    }

    public void ImageStage1()
    {
        imagecontroller.imgnumber = 1;
    }

    public void ImageStage2()
    {
        imagecontroller.imgnumber = 2;
    }
}
