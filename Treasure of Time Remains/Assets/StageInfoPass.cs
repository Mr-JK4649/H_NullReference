using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageInfoPass : MonoBehaviour
{
    [SerializeField] private int stageNum;

    private void Start()
    {
        ScoreManager.Instance.StageNum = stageNum;
        ScoreManager.Instance.score = 0;
    }
}
