using Chronos;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleTrigger : MonoBehaviour
{
    public GameObject ps;
    GameObject pss;
    GlobalClock[] gc;
    const string chain_Name = "Chain";

    private void Start()
    {
        gc = GameObject.Find("Timekeeper").GetComponents<GlobalClock>();
    }

    private void FixedUpdate()
    {
        if (gc[1].timeScale == 0)
            SummonParticleSystem();
        if (gc[1].timeScale == 1)
        {
            Destroy(pss);
            pss = null;
        }
    }

    void SummonParticleSystem() {
        if (!pss)
        {
            //オブジェクトの位置に鎖を出現
            pss = Instantiate(ps, this.transform.position, Quaternion.identity);
            pss.name = chain_Name;
            pss.transform.rotation = new Quaternion(0, 0, 80f, 0);

            //Scaleの中で一番大きい値を取得
            float biggest = this.transform.localScale.x;
            if (this.transform.localScale.y > biggest) biggest = this.transform.localScale.y;
            if (this.transform.localScale.z > biggest) biggest = this.transform.localScale.z;

            //オブジェクトの大きさに合わせたサイズに調整
            pss.transform.localScale = new Vector3(biggest, biggest, biggest) / 2;
            
        }
        
    }
}
