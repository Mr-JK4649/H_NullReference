using UnityEngine;
using Chronos;


[RequireComponent(typeof(Timeline))]
public class ChronosObjectSimulator : MonoBehaviour
{
    [SerializeField] private Vector3 trans;             //ポジション
    [SerializeField] private Vector3 rotate;            //回転
    [SerializeField] private bool isGravity;            //重力
    private float gravity = 9.81f;                      //重力の強さ
    [SerializeField] private int gravity_Multiplier;    //重力の倍率
    private bool isGround;
    private GlobalClock _clock;
    private Transform t_Me;

    private void Start()
    {
        _clock = GameObject.Find("TimeKeeper").GetComponent<GlobalClock>();
        t_Me = this.gameObject.transform;
    }

    private void Update()
    {
        if(!isGround)
            t_Me.position += trans * _clock.timeScale;

        

        //   (_clock.timeScale * _clock.timeScale)   逆行に使う変数ｘ停止に使う変数
    }

    private void OnCollisionEnter(Collision other)
    {
        isGround = true;
        
    }

    private void OnCollisionExit(Collision collision)
    {
        isGround = false;
    }
}
