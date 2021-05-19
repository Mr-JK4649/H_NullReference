using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Chronos;
namespace UnityStandardAssets.Characters.ThirdPerson
{

    public class DaethDirecting : MonoBehaviour
    {
        //public GlobalClock gl;

        //public TimeControl time;

        ////public GameObject particleObject;//
        //public GameObject ParticleObject;

        //[SerializeField] private Animator DeathCam;

        ThirdPersonCharacter TPC;

        //[SerializeField] private GameObject Cam;
        //private Vector3 CamVectr;

        //private Vector3 Hero;

        //[SerializeField]
        //private GameObject mainCamera;
        //[SerializeField]
        //private GameObject otherCamera;

        //private Vector3 MainCamera_Rotation;

        //private GameObject prefab;
        //private GameObject HeroCameraSub;

        //public GameObject particleObject;
        // メインカメラを取得
        //Camera MainCam = Camera.main;

        //public Vector3 pos;

        [SerializeField] private float SecondSpeed;
        [SerializeField] private float MinuteSpeed;
        [SerializeField] private float speedMultiplier;
        [SerializeField] private GameObject SecondHand;
        [SerializeField] private GameObject MinuteHand;
        //private GlobalClock[] g_clock;
        public GlobalClock[] g_clock = new GlobalClock[3];
        //public GameManager gg;
        [SerializeField] private GameObject canvas;
        private bool TimeFlg;
        private bool Retry;

        [SerializeField] private Image ShineImage;
        private Color ImageColor;
        private float Alpha;
        private float Imagespeed;

        public AudioClip TimeSound;
        public AudioClip DeathSound;
        AudioSource audioSource;

        private float Count;
        private float Death;

        //public Material myMaterial;
        public GameObject MainCam;
        public GameObject Prefab;

        private Vector3 HeroPos;

        private bool MakeupPrefab;

        public Animator DeathAnim;

        //private GameObject DeathObj;

        public GameObject ThisObj;
        public TimeControl TimeLineeee;

        private static int RetryCount = 0;
        public GameObject RetryText;
        public GameObject RetryObj;
        public GameObject RetryMinutes;

        //private Scene loadScene;


        private void Start()
        {
            TPC = GetComponent<ThirdPersonCharacter>();
            //プレハブをGameObject型で取得
            //Prefab = (GameObject)Resources.Load("HeroCameraSub");
            //HeroCameraSubプレハブを元に、インスタンスを生成
            //HeroCameraSub = Instantiate(Prefab, new Vector3(0f, 0f, 0f), Quaternion.identity);
            //HeroCameraSubのオブジェクトに名づけ
            //HeroCameraSub.name = "HeroCameraSub";
            //Instantiate(Prefab, new Vector3(0f, 0f, 0f), Quaternion.identity);

            //透明度を０にする
            Alpha = 0;
            //TimeKeeperのGlobalClockを取得
            g_clock = GameObject.Find("Timekeeper").GetComponents<GlobalClock>();
            //Shineのimageを取得
            ShineImage = GameObject.Find("Shine").GetComponent<Image>();
            //ShineのColor取得
            ImageColor = ShineImage.color;
            //ShineのColor更新
            ShineImage.color = new Color(ImageColor.r, ImageColor.g, ImageColor.b, Alpha);
            //透明度の値の加算値
            Imagespeed = 0.01f;
            //Componentを取得
            audioSource = GameObject.Find("ClockCanvas2").GetComponent<AudioSource>();
            //死亡演出に使うCanvasを非アクティブ化
            canvas.SetActive(false);
            //死亡したときのフラグをfalseに
            TimeFlg = false;
            //
            Retry = false;
            //
            Count = 0;
            //
            MakeupPrefab = false;
            //リトライ数表示のテキストを非表示
            //RetryText.SetActive(false);
            //リトライ数の情報を持つオブジェクトを非表示
            RetryObj.SetActive(false);
            // 現在のScene名を取得する
            //loadScene = SceneManager.GetActiveScene();
            //ThisObj=GetComponentInChildren("")
            ////
            //DeathObj = GameObject.Find("DeathOrbs");
            ////
            //DeathAnim = DeathObj.GetComponent<Animator>();
            //DeathAnim = GameObject.Find("DeathOrbs").GetComponent<Animator>();
        }

        //private void OnCollisionEnter(Collision collision)
        //{
        //    if (collision.gameObject.tag == "Object") //Objectタグの付いたゲームオブジェクトと衝突したか判別
        //    {
        //        // TimeTextプレハブを元に、インスタンスを生成
        //        ParticleObject = Instantiate(Object);
        //    }
        //}

        private void Update()
        {
            //Debug.Log(RetryCount);
            //DeathAnim.SetBool("Death", true);
            //CamVectr = Cam.gameObject.transform.position;
            //Debug.Log(CamVectr);
            //Debug.Log(Cam.transform.position);
            //Debug.Log(Cam.transform.localPosition);

            //Debug.Log(g_clock[2].timeScale);

            if (TimeFlg)
            {
                //Timekeeper.instance.Clock("Root").localTimeScale = 0;
                //Timekeeper.instance.Clock("Player").localTimeScale = 0;
                if (MakeupPrefab)
                {
                    //for (int x = 0; x < 4; x++)
                    //{
                    //    HeroPos[x] = this.gameObject.transform.position;
                    //}
                    HeroPos = this.gameObject.transform.position;
                    //for (int x = 0; x < 4; x++)
                    //{
                    //    Instantiate(Prefab, new Vector3(HeroPos[x].x, HeroPos[x].y, HeroPos[x].z), Quaternion.identity);
                    //}
                    Instantiate(Prefab, new Vector3(HeroPos.x, HeroPos.y + 0.5f, HeroPos.z), Quaternion.identity);
                    //GameObject aa = Instantiate(Prefab, new Vector3(HeroPos.x, HeroPos.y+0.5f, HeroPos.z), Quaternion.identity);
                    //Prefab.name = "DeathOrbs";
                    //
                    //DeathObj = GameObject.Find("DeathOrbs(Clone)");
                    //
                    //DeathAnim = aa.GetComponent<Animator>();
                    //DeathAnim = Prefab.GetComponent<Animator>();
                    //DeathAnim.SetTrigger("Die");
                    
                    
                    ThisObj.gameObject.GetComponent<SkinnedMeshRenderer>().enabled = false;
                    //DeathAnim.Play("DeathAnim");
                    //Debug.Log("tinpo!");
                    MakeupPrefab = false;
                }


                if (Count <= 120)
                {
                    //this.gameObject.transform.GetComponent<Renderer>().material.color = myMaterial.color;
                    //MainCam.transform.GetComponent<Renderer>().material.color = myMaterial.color;
                    //MainCam.transform.GetComponent<ImageEffect>().enabled = true;
                    Timekeeper.instance.Clock("Root").localTimeScale = 0;
                    Timekeeper.instance.Clock("Player").localTimeScale = 0;

                    //Instantiate(Prefab, new Vector3(HeroPos.x, HeroPos.y, HeroPos.z), Quaternion.identity);

                    Count++;
                }
                else if (Alpha <= 1)
                {
                    TimeLineeee.enabled = false;
                    ThisObj.gameObject.GetComponent<SkinnedMeshRenderer>().enabled = true;
                    //DeathAnim.SetFloat(Animator.StringToHash("speed"), -1);
                    //DeathAnim.Play("DeathAnim",0,1f);
                    //MainCam.transform.GetComponent<ImageEffect>().enabled = false;
                    //localTimeScaleをマイナスの値にして巻き戻す
                    Timekeeper.instance.Clock("Root").localTimeScale = -3;
                    //Timekeeper.instance.Clock("Object").localTimeScale = -3;
                    Timekeeper.instance.Clock("Player").localTimeScale = -3;
                    Timekeeper.instance.Clock("Particle").localTimeScale = -3;

                    //g_clock[2].localTimeScale = -1;
                    //透明度を上げていく
                    Alpha += Imagespeed;
                    //透明度更新
                    ShineImage.color = new Color(ImageColor.r, ImageColor.g, ImageColor.b, Alpha);

                    //時計の針を回転
                    MinuteHand.transform.Rotate(0, 0, MinuteSpeed * g_clock[2].timeScale);
                    SecondHand.transform.Rotate(0, 0, SecondSpeed * g_clock[2].timeScale);

                    //ピッチを上げる
                    audioSource.pitch += 0.01f;
                }
            }
            if (Alpha >= 1)
            {
                //リトライtextにリトライ数を代入
                RetryText.GetComponent<Text>().text = "リトライ ×" + RetryCount.ToString();
                //リトライtextを表示
                //RetryText.SetActive(true);
                //リトライ数を表示
                RetryObj.SetActive(true);
                if (/*!Retry &&/*/ Count <= 180)
                {
                    RetryMinutes.transform.Rotate(0, 0, MinuteSpeed * g_clock[2].timeScale);
                    if (!Retry && Count >= 180)
                    {
                        //リトライ数をカウントする
                        RetryCount++;
                        Retry = true;
                    }
                }
                Count++;
                //Debug.Log(RetryCount);
                if (Count >= 240)
                {
                    // 現在のScene名を取得する
                    Scene loadScene = SceneManager.GetActiveScene();
                    // Sceneの読み直し
                    SceneManager.LoadScene(loadScene.name);
                }
                //switch (Death)
                //{
                //    case 0:
                //        //SceneManager.LoadScene("stage0_gameover");
                //        break;
                //    case 1:
                //        //SceneManager.LoadScene("gameover(kari)");
                //        break;
                //    case 2:
                //        //SceneManager.LoadScene("stage1_gameover");
                //        break;
                //    case 3:
                //        //SceneManager.LoadScene("gameover_stage");
                //        break;
                //    case 4:
                //        //SceneManager.LoadScene("stage2_gameover");
                //        break;
                //    case 5:
                //        //SceneManager.LoadScene("gameover_stage2");
                //        break;
                //}
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Goal")
            {
                //ゴールしたときリトライ回数を０にする
                RetryCount = 0;
            }
            if (other.gameObject.tag == "Death")
            {
                if (!TimeFlg)
                {
                    MakeupPrefab = true;
                }
                Death = 1;
                //g_clock[0].localTimeScale = -1;
                //プレイヤーが死ぬオブジェクトに当たった時死亡演出のフラグをtrueにする
                TimeFlg = true;

                //死亡時の時計の音を再生
                audioSource.PlayOneShot(TimeSound);
            }
            if (other.gameObject.tag == "Death0")
            {

                if (!TimeFlg)
                {
                    MakeupPrefab = true;
                }

                Death = 0;
                //g_clock[0].localTimeScale = -1;
                //プレイヤーが死ぬオブジェクトに当たった時死亡演出のフラグをtrueにする
                TimeFlg = true;


                //死亡時の時計の音を再生
                audioSource.PlayOneShot(TimeSound);
            }
            if (other.gameObject.tag == "Death2")
            {
                if (!TimeFlg)
                {
                    MakeupPrefab = true;
                }
                Death = 2;
                //g_clock[0].localTimeScale = -1;
                //プレイヤーが死ぬオブジェクトに当たった時死亡演出のフラグをtrueにする
                TimeFlg = true;

                //死亡時の時計の音を再生
                audioSource.PlayOneShot(TimeSound);
            }
            if (other.gameObject.tag == "Death3")
            {
                if (!TimeFlg)
                {
                    MakeupPrefab = true;
                }
                Death = 3;
                //g_clock[0].localTimeScale = -1;
                //プレイヤーが死ぬオブジェクトに当たった時死亡演出のフラグをtrueにする
                TimeFlg = true;

                //死亡時の時計の音を再生
                audioSource.PlayOneShot(TimeSound);
            }
            if (other.gameObject.tag == "Death4")
            {
                if (!TimeFlg)
                {
                    MakeupPrefab = true;
                }
                Death = 4;
                //g_clock[0].localTimeScale = -1;
                //プレイヤーが死ぬオブジェクトに当たった時死亡演出のフラグをtrueにする
                TimeFlg = true;

                //死亡時の時計の音を再生
                audioSource.PlayOneShot(TimeSound);
            }
            if (other.gameObject.tag == "Death5")
            {
                if (!TimeFlg)
                {
                    MakeupPrefab = true;
                }
                Death = 5;
                //g_clock[0].localTimeScale = -1;
                //プレイヤーが死ぬオブジェクトに当たった時死亡演出のフラグをtrueにする
                TimeFlg = true;

                //死亡時の時計の音を再生
                audioSource.PlayOneShot(TimeSound);
            }
        }

        private void OnTriggerStay(Collider other)
        {
            //ThirdPersonCharacters.

            //Transform myTransform = this.gameObject.transform;

            // 座標を取得
            //Vector3 pos = myTransform.position;
            //pos.z -= 1.5f;    // z座標へ0.01加算

            switch (other.gameObject.tag)
            {
                case "Death":
                    canvas.SetActive(true);
                    TPC.Speed = 0f;
                    break;
                case "Death0":
                    //SceneManager.LoadScene("gameover(kari)");
                    canvas.SetActive(true);
                    TPC.Speed = 0f;
                    break;
                case "Death1":
                    canvas.SetActive(true);
                    TPC.Speed = 0f;
                    //SceneManager.LoadScene("stage1_gameover");
                    break;
                //case "Death3":
                case "Death2":
                    //死亡演出用のCanvasをアクティブ化
                    canvas.SetActive(true);
                    //プレイヤーの移動量を０にする
                    TPC.Speed = 0f;
                    //g_clock[0].localTimeScale = -1;
                    //RotateClock();
                    // メインカメラを取得
                    //Camera camera = Camera.main;
                    // カメラを前に移動し続ける
                    //camera.gameObject.transform.Translate(new Vector3(0.0f, 0.0f, 1.0f));
                    //CamVectr = camera.gameObject.transform.position;//メインカメラの座標を取得
                    //Vector3 _Rotation = gameObject.transform.localEulerAngles;
                    //CamVectr = GameObject.Find("Main Camera").transform.position;//カメラの座標を取得
                    //CamVectr = Cam.gameObject.transform.position;
                    //Cam.transform.SetParent(null);//カメラをプレイヤーの子からはずす
                    //TPC.m_MoveSpeedMultiplier = 0f;//プレイヤーの移動量を０にする
                    //Hero = this.gameObject.transform.position;//プレイヤーの座標を取得
                    ////Cam.gameObject.transform.TransformPoint(new Vector3(CamVectr.x, CamVectr.y, CamVectr.z + Hero.z));
                    //Cam.gameObject.transform.localPosition =
                    //    new Vector3(CamVectr.x, CamVectr.y, CamVectr.z + Hero.z);//カメラの座標を修正
                    //Instantiate(particleObject, Hero, Quaternion.identity); //パーティクル用ゲームオブジェクト生成
                    //mainCamera.SetActive(!mainCamera.activeSelf);
                    //otherCamera.SetActive(!otherCamera.activeSelf);
                    ////Destroy(this.gameObject);//プレイヤーを削除
                    //Hero = GameObject.Find("Necessary2nd (1)").transform.position;
                    //otherCamera.transform.position = mainCamera.transform.position;//サブカメラの座標を修正
                    //otherCamera.transform.localEulerAngles = mainCamera.transform.localEulerAngles;//サブカメラの角度を修正
                    ////Debug.Log(CamVectr.z);
                    //GameObject.Find("SubCamera").transform.position =
                    //    new Vector3(CamVectr.x, CamVectr.y, CamVectr.z);//カメラの座標を修正
                    //camera.gameObject.transform.Translate(new Vector3(CamVectr.x, CamVectr.y, 100));
                    //Debug.Log(Hero.z);
                    //Debug.Log(CamVectr.z);
                    //Vector3 tmp = GameObject.Find("hogehoge").transform.position;
                    //pos.z -= 1.5f;    // z座標へ0.01加算
                    //SceneManager.LoadScene("gameover_stage");
                    //DeathCam.SetTrigger("Death");
                    break;
                case "Death3":  //satge2のゲームオーバーシーンに遷移
                    canvas.SetActive(true);
                    TPC.Speed = 0f;
                    //SceneManager.LoadScene("stage2_gameover");
                    break;
                case "Death4":  //satge2のゲームオーバーシーンに遷移
                    canvas.SetActive(true);
                    TPC.Speed = 0f;
                    //SceneManager.LoadScene("stage2_gameover");
                    break;
                case "Death5":
                    canvas.SetActive(true);
                    TPC.Speed = 0f;
                    break;
            }
        }

        //private void RotateClock()
        //{
        //    this.gameObject.transform.Rotate(0, 0, speed * g_clock[1].timeScale);
        //    MinuteHand.gameObject.transform.Rotate(0, 0, MinuteSpeed * g_clock[1].timeScale);
        //    SecondHand.gameObject.transform.Rotate(0, 0, SecondSpeed * g_clock[1].timeScale);
        //}

        //private void OnTriggerStay(Collider other)
        //{
        //    //if (other.gameObject.tag == "Slow" && gl.localTimeScale != -1) {
        //    //    if(gl.localTimeScale > 0.3f)
        //    //        gl.localTimeScale = 0.3f;

        //    //    gl.localTimeScale -= 0.001f;
        //    //    if (gl.localTimeScale <= 0.01f) gl.localTimeScale = 0.01f;
        //    //}
        //}

        //private void OnTriggerExit(Collider other)
        //{
        //if (other.gameObject.tag == "Slow") {
        //    gl.localTimeScale = 1;
        //}
        //}
    }

}