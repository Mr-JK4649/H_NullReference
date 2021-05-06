using UnityEngine;
using UnityEngine.UI;

public class SetGetscore : MonoBehaviour
{

    [SerializeField] private Text score;
    [SerializeField] private Text hscore;
    [SerializeField] private Text result;

    private void Start()
    {
        int num = ScoreManager.Instance.StageNum;
        int sc = ScoreManager.Instance.score;
        if (ScoreManager.Instance.stage_Highscore[num] < sc)
            ScoreManager.Instance.stage_Highscore[num] = sc;
        int hs = ScoreManager.Instance.stage_Highscore[num];

        score.text = sc.ToString();
        hscore.text = hs.ToString();
        result.text = "Stage" + num.ToString() + "RESULT";
    }
    private void Update()
    {
        Debug.Log(score);
    }
}
