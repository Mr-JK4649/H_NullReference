﻿using UnityEngine;
using UnityEngine.UI;

public class SetGetscore : MonoBehaviour
{
    private string[] difficult = new string[4] { "★☆☆☆", "★★☆☆", "★★★☆", "★★★★" };
 
    [SerializeField] private Text score;
    [SerializeField] private Text hscore;
    //[SerializeField] private Text result;
    [SerializeField] private Image button;
    [SerializeField] private Text next;
    [SerializeField] private Text orb;
    [SerializeField] private Text orbScore;
    [SerializeField] private Text ability;
    [SerializeField] private Text abilityScore;
    [SerializeField] private Text retry;
    [SerializeField] private Text retryScore;
    [SerializeField] private Text level;
    [SerializeField] private Text bonus;
    [SerializeField] private GameObject mozaik;

    [SerializeField] private int po_Orb;
    [SerializeField] private int po_Abi;
    [SerializeField] private int po_Ret;

    private float alpha = 1;
    private float flg = 1;

    

    private void Start()
    {
        
        int num = ScoreManager.Instance.StageNum;       //ステージ番号
        int orbNum = ScoreManager.Instance.orb;         //オーブ数
        int abi = ScoreManager.Instance.keptAbility;    //残ったゲージ
        int ret = ScoreManager.Instance.retries;        //リトライ回数
        int hsc = ScoreManager.Instance.stage_Highscore[num];   //ハイスコアの取得


        //最終ステージのみNextStageの文字を変える
        if (num == 3)
        {
            mozaik.SetActive(false);
            next.text = "Title";
        }

        //テキストとして反映
        orb.text = orbNum.ToString();
        orbScore.text = (orbNum * po_Orb).ToString("N0");
        ability.text = abi.ToString();
        abilityScore.text = (abi * po_Abi).ToString("N0");
        retry.text = ret.ToString();
        retryScore.text = (ret * po_Ret).ToString("N0");
        level.text = difficult[num];
        bonus.text = "x " + (num+1).ToString();

        //スコアの計算と反映
        int sc = (orbNum * po_Orb + abi * po_Abi + ret * po_Ret) * (num + 1);
        score.text = sc.ToString("N0");

        //ハイスコアの更新と反映
        if (sc > hsc) ScoreManager.Instance.stage_Highscore[num] = sc;
        hscore.text = ScoreManager.Instance.stage_Highscore[num].ToString("N0");

        
    }
    private void FixedUpdate()
    {


        alpha -= Time.deltaTime * flg;
        if (alpha <= 0) { alpha = 0; flg *= -1; }
        if (alpha >= 1) { alpha = 1; flg *= -1; }

        button.color = new Color(1, 1, 1, alpha);
    }
}
