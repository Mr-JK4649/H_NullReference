using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Chronos;

public class WarpPoint : MonoBehaviour
{

    public GlobalClock gl;

    public TimeControl time;
    private void OnTriggerEnter(Collider other)
    {

        switch (other.gameObject.tag) {
            case "Death":
                SceneManager.LoadScene("gameover(kari)");
                break;
            case "Death2":
                SceneManager.LoadScene("stage1_gameover");
                break;
            case "Death3":
                SceneManager.LoadScene("gameover_stage");
                break;
            case "Death4":  //satge2のゲームオーバーシーンに遷移
                SceneManager.LoadScene("stage2_gameover");
                break;
            case "Death5":  //せいやのsatge2のゲームオーバーシーンに遷移
                SceneManager.LoadScene("gameover_stage2");
                break;
            case "Dust":
                Vector3 xyz = other.gameObject.transform.position;
                xyz.z += 130f;

                GameObject pss = Instantiate(other.gameObject,xyz,Quaternion.Euler(90,0,0));
                pss.name = "StageDust";
                Destroy(other.gameObject,5f);
                break;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        //if (other.gameObject.tag == "Slow" && gl.localTimeScale != -1) {
        //    if(gl.localTimeScale > 0.3f)
        //        gl.localTimeScale = 0.3f;

        //    gl.localTimeScale -= 0.001f;
        //    if (gl.localTimeScale <= 0.01f) gl.localTimeScale = 0.01f;
        //}
    }

    private void OnTriggerExit(Collider other)
    {
        //if (other.gameObject.tag == "Slow") {
        //    gl.localTimeScale = 1;
        //}
    }
}