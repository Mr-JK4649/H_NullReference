using Chronos;
using UnityEngine;

public class StageDust : MonoBehaviour
{
    private GlobalClock[] g_clock;
    private ParticleSystem ps;
    private RectTransform ping1;
    private RectTransform ping2;
    private Renderer rend;
    public Quaternion rott;
    
    private void Start()
    {
        g_clock = GameObject.Find("Timekeeper").GetComponents<GlobalClock>();
        ping1 = GameObject.Find("ping1").GetComponent<RectTransform>();
        ping2 = GameObject.Find("ping2").GetComponent<RectTransform>();
        rend = this.gameObject.GetComponent<Renderer>();
        ps = this.GetComponent<ParticleSystem>();
    }

    private void FixedUpdate()
    {
        float timeS = (int)g_clock[1].timeScale;

        //if (timeS == 0) ps.Stop();
        if (timeS == 1 && !ps.isPlaying) { ps.Play(); Debug.Log("開始"); }

        StageDustMatChange();
    }

    private void StageDustMatChange(){

        rott = ping1.rotation;
        Quaternion rot2 = ping2.rotation;
        Vector2 offs = new Vector2();
        rott.y /=  0.083f;
        switch ((int)Mathf.Abs(rott.y)) {
            case 0:  offs = new Vector2(0f, -0.08f);    break;
            case 1:  offs = new Vector2(0f, -0.16f);    break;
            case 2:  offs = new Vector2(0f, -0.24f);    break;
            case 3:  offs = new Vector2(0f, -0.32f);    break;
            case 4:  offs = new Vector2(0f, -0.40f);    break;
            case 5:  offs = new Vector2(0f, -0.50f);    break;
            case 6:  offs = new Vector2(0f, -0.58f);    break;
            case 7:  offs = new Vector2(0f, -0.66f);    break;
            case 8:  offs = new Vector2(0f, -0.74f);    break;
            case 9:  offs = new Vector2(0f, -0.80f);    break;
            case 10: offs = new Vector2(0f, -0.91f);    break;
            case 11: offs = new Vector2(0f, -0.10f);    break;
        }

        rend.material.SetTextureOffset("_MainTex", offs);

    }

}
