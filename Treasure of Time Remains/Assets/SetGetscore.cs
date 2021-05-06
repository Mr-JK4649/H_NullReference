using UnityEngine;
using UnityEngine.UI;

public class SetGetscore : MonoBehaviour
{

    [SerializeField] private Text score;
    [SerializeField] private Text hscore;
    //[SerializeField] private Text result;
    [SerializeField] private Image button;
    [SerializeField] private Text next;
    [SerializeField] private GameObject mozaik;

    private float alpha = 1;
    private float flg = 1;

    private void Start()
    {
        int num = ScoreManager.Instance.StageNum;
        int sc = ScoreManager.Instance.score;
        if (ScoreManager.Instance.stage_Highscore[num] < sc)
            ScoreManager.Instance.stage_Highscore[num] = sc;
        int hs = ScoreManager.Instance.stage_Highscore[num];

        if (num == 3)
        {
            mozaik.SetActive(false);
            next.text = "Title";
        }

        //テキストとして反映
        score.text = sc.ToString();
        hscore.text = hs.ToString();
        //result.text = "Stage" + num.ToString() + "RESULT";
    }
    private void FixedUpdate()
    {


        alpha -= Time.deltaTime * flg;
        if (alpha <= 0) { alpha = 0; flg *= -1; }
        if (alpha >= 1) { alpha = 1; flg *= -1; }

        button.color = new Color(1, 1, 1, alpha);
    }
}
