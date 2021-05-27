using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetGetscore : MonoBehaviour
{
    private string[] difficult = new string[4] { "★☆☆☆", "★★☆☆", "★★★☆", "★★★★" };
 
    [SerializeField] private Text score;    //スコアtext
    [SerializeField] private Text hscore;   //ハイスコアtext

    [SerializeField] private Image button;  //次のステージボタン
    [SerializeField] private Text next;     //次のステージtext
    [SerializeField] private Text orb;      //オーブ数text
    [SerializeField] private Text orbScore; //オーブスコアtext
    [SerializeField] private Text ability;      //ゲージ残量text
    [SerializeField] private Text abilityScore; //ゲージ残量スコアtext
    [SerializeField] private Text retry;        //リトライ回数text
    [SerializeField] private Text retryScore;   //リトライ回数スコアtext

    [SerializeField] private GameObject mozaik; //背景モザイク

    [SerializeField] private int po_Orb;        //オーブ点数
    [SerializeField] private int po_Abi;        //ゲージ点数
    [SerializeField] private int po_Ret;        //リトライ点数

    [SerializeField] private AudioMixer _mix;           //SEボリューム変更ミキサー
    [SerializeField] private AnimationCurve _mixCurve;  //音の変則カーブ

    [SerializeField] private AudioSource _audio;        //スピーカ
    [SerializeField] private AudioClip _bestSound;      //音
    [SerializeField] private AudioClip _sound;          //音

    private float alpha = 1;        //次のボタン点滅アルファ
    private float flg = 1;          //次のボタンフラグ

    

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
            next.text = "タイトル";
        }

        //テキストとして反映
        orb.text = orbNum.ToString();
        orbScore.text = (orbNum * po_Orb).ToString("N0");
        ability.text = abi.ToString();
        abilityScore.text = (abi * po_Abi).ToString("N0");
        retry.text = ret.ToString();
        retryScore.text = (ret * po_Ret).ToString("N0");


        //スコアの計算と反映
        int sc = orbNum * po_Orb + abi * po_Abi + ret * po_Ret;
        if (sc < 0) sc = 0;
        score.text = sc.ToString("N0");

        //ハイスコアの更新と反映
        if (sc > hsc)
        {
            ScoreManager.Instance.stage_Highscore[num] = sc;
            _audio.PlayOneShot(_bestSound);
        }
        else _audio.PlayOneShot(_sound);
        hscore.text = ScoreManager.Instance.stage_Highscore[num].ToString("N0");

        
    }

    private float count = 0;

    private void FixedUpdate()
    {
        count += Time.deltaTime;
        float db = _mixCurve.Evaluate(count);

        _mix.SetFloat("MasterOto", db);

        Debug.Log(db);

        alpha -= Time.deltaTime * flg;
        if (alpha <= 0) { alpha = 0; flg *= -1; }
        if (alpha >= 1) { alpha = 1; flg *= -1; }

        button.color = new Color(1, 1, 1, alpha);
    }
}
