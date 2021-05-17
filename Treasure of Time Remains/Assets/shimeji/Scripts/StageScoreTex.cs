using UnityEngine;
using UnityEngine.UI;

public class StageScoreTex : MonoBehaviour
{
    private Text this_Tex;
    private int currentScore = 0;

    private void Start()
    {
        this_Tex = GetComponent<Text>();
    }

    private void FixedUpdate()
    {
        int sc = ScoreManager.Instance.orb * 500;
        int add = 500 / 15;
        if (currentScore < sc) currentScore += add;
        if (currentScore > sc) currentScore = sc;

        //スコアの反映
        this_Tex.text = "スコア " + currentScore.ToString("N0");
    }
}
