using System.Collections;
using System.Collections.Generic;
using UnityEngine;


internal enum vibrateType
{
    VERTICAL,
    HORIZONTAL
}

public class Vibratecontroller_Z : MonoBehaviour
{
    [SerializeField] private vibrateType vibratetype;
    [Range(0, 1)] [SerializeField] private float vibrateRange;
    [SerializeField] private float vibrateSpeed;


    private float initPosition; //初期ポジション
    private float newPosition; //新規ポジション
    private float minPosition; //ポジションの下限
    private float maxPosition; //ポジションの上限
    private bool directionToggle; //振動方向の切り替えようトグル オフ:値が小さくなる方向へ オン:値が大きくなる方向へ
    void Start()
    {
        //初期ポジションの設定を振動タイプ毎に分ける
        switch (this.vibratetype)
        {
            case vibrateType.VERTICAL:
                this.initPosition = transform.localPosition.y;
                break;
            case vibrateType.HORIZONTAL:
                this.initPosition = transform.localPosition.x;
                break;
        }

        this.newPosition = this.initPosition;
        this.minPosition = this.initPosition - this.vibrateRange;
        this.maxPosition = this.initPosition + this.vibrateRange;
        this.directionToggle = false;


        Debug.Log("newPosition"+ this.newPosition);
        Debug.Log("initPosition"+ this.initPosition);
        
    }

    // Update is called once per frame
    void Update()
    {
        Vibrate();
    }

    private void Vibrate()
    {
        //ポジションが振動幅の範囲を超えた場合、振動方向を切り替える
        if (this.newPosition <= this.minPosition || this.maxPosition <= this.newPosition){
            this.directionToggle = !this.directionToggle;
        }

        //新規ポジションを設定
        this.newPosition = this.directionToggle ? this.newPosition + (vibrateSpeed * Time.deltaTime) : this.newPosition - (vibrateSpeed * Time.deltaTime);
        this.newPosition = Mathf.Clamp(this.newPosition, this.minPosition, this.maxPosition);


        switch (this.vibratetype)
        {
            case vibrateType.VERTICAL:
                this.transform.localPosition = new Vector3(0, this.newPosition, 0);
                break;
            case vibrateType.HORIZONTAL:
                this.transform.localPosition = new Vector3(this.newPosition, 0f, 0f);
                break;
        }

    }
}
