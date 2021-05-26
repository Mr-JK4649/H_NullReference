using UnityEngine;
using UnityEngine.UI;

public class stage1slider : MonoBehaviour
{
    Slider distanceSlider;
    //float z = 

    // Use this for initialization
    void Start()
    {
        distanceSlider = GetComponent<Slider>();

        float Goal = 200f;
        float Start = 0f;

        //ゴール地点設定
        distanceSlider.maxValue = Goal;

        //スタート地点の設定
        distanceSlider.value = Start;


    }

    // Update is called once per frame
    void Update()
    {

    }

}
