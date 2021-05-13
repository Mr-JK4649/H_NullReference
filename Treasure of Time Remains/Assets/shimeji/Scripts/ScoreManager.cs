﻿using System;

public class ScoreManager : SingletonMonoBehaviour<ScoreManager>
{
    public int[] stage_Highscore = new int[4];  //そのステージのハイスコア
    public int StageNum;                        //プレイしたステージの番号
    public int keptAbility;                     //クリア時に保持してた能力残数
    public int retries;                         //リトライ回数
    public int orb;                             //回収したオーブの数
}
