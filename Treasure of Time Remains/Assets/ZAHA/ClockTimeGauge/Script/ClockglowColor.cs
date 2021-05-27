using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClockglowColor : MonoBehaviour
{
    Image clockimg;
    Color mycolor;

  
    // Start is called before the first frame update
    void Start()
    {
        
        clockimg = GetComponent<Image>();

        Debug.Log(mycolor);
    }

    public void Effect_Clock_Color()
    {
        this.clockimg.color = new Color(1f, 1f, 1f, 1f);
    }
    public void Effect_Clock_Color_OFF()
    {
       
        this.clockimg.color = new Color(0f, 1f ,1f, 1f);
    }
}
