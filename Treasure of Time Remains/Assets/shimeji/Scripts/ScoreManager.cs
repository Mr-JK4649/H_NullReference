using System;

public class ScoreManager : SingletonMonoBehaviour<ScoreManager>
{
    public int score;
    public int[] stage_Highscore = new int[4];
    public int StageNum;
    
}
