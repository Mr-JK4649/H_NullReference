using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageInfoPass : MonoBehaviour
{
    [SerializeField] private int stageNum;

    private void Start()
    {
        ScoreManager.Instance.StageNum = stageNum;
        ScoreManager.Instance.orb = 0;
        
    }

    public void AddRestartNum() {
        ScoreManager.Instance.retries += 1;
    }

    //ステージセレクトに戻った時
    public void ResetStageInfo() {
        ScoreManager.Instance.StageNum = 0;
        ScoreManager.Instance.retries = 0;
        ScoreManager.Instance.keptAbility = 0;
        ScoreManager.Instance.orb = 0;
    }
}
