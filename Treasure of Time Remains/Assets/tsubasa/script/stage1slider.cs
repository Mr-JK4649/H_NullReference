using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stage1slider : MonoBehaviour
{
    float fulldistance;
    [SerializeField]
    private Transform player;
    [SerializeField]
    private Transform goal;
    [SerializeField]
    private Slider length;

    void Start()
    {
        fulldistance = Vector3.Distance(player.position, goal.position);
    }

    private void FixedUpdate()
    {
        float dis = Vector3.Distance(player.position, goal.position);
        float distovalue = dis / fulldistance;
        length.value = 1 - distovalue;
    }
    //    // スライダーを取得する
    //    _slider = GameObject.Find("Slider").GetComponent<Slider>();
    //}

    //void Update()
    //{
    //    if (startFlag)
    //    {
    //        //だいたい1秒ごとに処理を行う
    //        timeleft -= Time.deltaTime;
    //        if (timeleft <= 0.0)
    //        {
    //            timeleft = 1.0f;
    //            _hp += 1f;
    //            if (_hp > 20)
    //            {

    //                //以下の記述だと元に戻る。他の処理をしたいときはここに書く
    //                _hp = 0;
    //            }
    //            // HPゲージに値を設定
    //            _slider.value = _hp;
    //        }
    //    }
    //}

}
//    float hp = 20;

//    [SerializeField]
//    private int minute;
//    [SerializeField]
//    private float seconds;
//    //前のUpdateの時の秒数
//    private float oldSeconds;

//    Vector3 tmp = GameObject.Find("ThirdPersonController").transform.position;
//    //float z = tmp.z;

//    Slider hpSlider;

//    // Use this for initialization
//    void Start()
//    {
//        minute = 0;
//        seconds = 0f;
//        oldSeconds = 0f;

//        hpSlider = GetComponent<Slider>();
//        hpSlider.maxValue = hp;
//        hpSlider.value = 0;
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        seconds += Time.deltaTime;
//        if (minute == 5f)
//        {
//            hp += 1f;
//            hpSlider.value = hp;
//        }
//    }
//}
