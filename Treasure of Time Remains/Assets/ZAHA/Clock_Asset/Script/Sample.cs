using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sample : MonoBehaviour
{
	//UI_Orb_prefab ui_orb;
	//[SerializeField]
	//GameObject UI_Orb;
	[SerializeField] private ClockGauge clockGauge;

	[SerializeField] GameObject clock_anim_obj;
	Clock_Animation clock_animation;


	[SerializeField]
	Camera _camera3d;
	[SerializeField]
	Camera _camera2d;
	[SerializeField]
	Transform[] _2dEffectTransforms;
	[SerializeField]
	Transform _Player;
	[SerializeField]
	RectTransform ClockUI;


	private const float Recovery = 0.2f;

	public bool effectStatus;//effect状態フラグ

	float _footerUiPlaneDistanceFromCamera = 2f;

	float _effectDuration = 1f;
	bool _useBezier = true;

	// エフェクト関連
	class Effect
	{
		public Transform transform;
		public Transform srcTransform;
		public Transform dstTransform;
		public float time;
		public float uiPlaneDistanceFromCamera;

		public bool animationflg;
	}

	Effect[] _2dEffects;

	int _2dEffectIndex;

	void Start()
	{
		//_2dEffectTransforms = new Transform[10];

		//ui_orb = UI_Orb.GetComponent<UI_Orb_prefab>();

		//for (int i = 0; i < 10; i++)
		//{
  //          _2dEffectTransforms[i] = ui_orb.orb_clone[i].gameObject.GetComponent<Transform>();
  //          Debug.Log("10回");
		//}

		//instance作成
		_2dEffects = new Effect[_2dEffectTransforms.Length];

		clock_animation = clock_anim_obj.GetComponent<Clock_Animation>();
		//長さ文for文回す
		for (int i = 0; i < _2dEffects.Length; i++)
		{
			_2dEffects[i] = new Effect();
            _2dEffects[i].transform = _2dEffectTransforms[i];
			_2dEffects[i].transform.gameObject.SetActive(false);
		}
	}

	void Update()
	{
		//     for (int i = 0; i < _2dEffects.Length; i++)
		//     {
		//Debug.Log(_2dEffects[i].animationflg);
		//if (_2dEffects[i].transform.gameObject.activeInHierarchy)
		//         {
		//	_2dEffects[i].animationflg = true;

		//	if (_2dEffects[i].animationflg && !_2dEffects[i].transform.gameObject.activeInHierarchy)
		//	{
		//		Debug.Log("終点");
		//	}
		//         }
		//         else
		//         {
		//	//_2dEffects[i].animationflg = false;
		//}
		//     }

		//Debug.Log(_2dEffects[i].transform.gameObject.name + _2dEffects[i].transform.gameObject.activeInHierarchy);


		
        float dt = Time.deltaTime;

		if (effectStatus)
		{

            Transform transform3d = null;
            transform3d = _Player; //プレイヤーのトランスフォームを代入

            // 2D側をランダムに選ぶ
            RectTransform transform2d = null;
            float uiDistanceFromCamera = 0f;

            transform2d = ClockUI; //UIのトランスフォームを代入
			uiDistanceFromCamera = _footerUiPlaneDistanceFromCamera;//

			// 3D→2Dに変換 //動かしている
			EmitEffect3dTo2d(transform3d, transform2d, uiDistanceFromCamera, _2dEffectIndex);
			
			//2Deffectカウントしていき
			//2dのeffectが長さを超えたらリセット

			_2dEffectIndex++;
			if (_2dEffectIndex >= _2dEffects.Length)
			{
				_2dEffectIndex = 0;
			}
			effectStatus = false;
		}
		
		UpdateEffects(dt);
    }

	void EmitEffect3dTo2d(Transform src, Transform dst, float uiPlaneDistanceFromCamera, int index)
	{
		var effect = _2dEffects[index];
		effect.time = 0f;
		effect.transform.gameObject.SetActive(true);
		effect.uiPlaneDistanceFromCamera = uiPlaneDistanceFromCamera;
		effect.srcTransform = src;
		effect.dstTransform = dst;

	}

	void UpdateEffects(float dt)
	{
		for (int i = 0; i < _2dEffects.Length; i++)
		{

			UpdateEffect2D(_2dEffects[i], dt);
        }

    }

	// 2D要素が3D空間にあったとしたらどこにあるか、を算出する
	static void Calc3dWorldPositionOfUi(

		out Vector3 worldPositionOut,
		Transform uiTransform,
		Camera camera2d,
		Camera camera3d,
		float uiPlaneDistanceFromCamera)
	{
		var worldPos2d = uiTransform.position; // 2D世界おけるワールド座標を得る
		var screenPos = camera2d.WorldToScreenPoint(worldPos2d); // スクリーン座標に変換
		var ray = camera3d.ScreenPointToRay(screenPos); // 3D世界におけるカメラから出たレイに変換
		var cosine = Vector3.Dot(ray.direction, camera3d.transform.forward)
			/ camera3d.transform.forward.magnitude; // ray.directionの長さは1固定なので割らずに済む
		var distance = uiPlaneDistanceFromCamera / cosine;
		worldPositionOut = camera3d.transform.position + (ray.direction * distance);

	}

    void UpdateEffect2D(Effect effect, float dt)
    {
		
		if (!effect.transform.gameObject.activeSelf)
        {
            return;
        }

		// 開始点のワールド座標を得る
		var srcWorldPos = effect.srcTransform.position;

        // 目標点のワールド座標を求める
        Vector3 dstWorldPos;
        Calc3dWorldPositionOfUi(
            out dstWorldPos,
            effect.dstTransform,
            _camera2d,
            _camera3d,
            effect.uiPlaneDistanceFromCamera);

        // 正規化時刻を求める
        var t = effect.time / _effectDuration;
        t *= t; // 加速した方がかっこいいので加速させてみる。このサンプルの本質には関係ない。
				// 補間する

		Debug.Log(t);
		//if (t >= 1)
		//{
			
		//	clockGauge.Recover(Recovery);
		//	clock_animation.Clock_On();
		//}
  //      else
  //      {
		//	clock_animation.Clock_Off();
  //      }

		Vector3 pos;
        if (_useBezier)
        {
            Vector3 controlPoint = (srcWorldPos + dstWorldPos) * 0.5f;
            controlPoint.y += 5f;
            Bezier(out pos, ref srcWorldPos, ref dstWorldPos, ref controlPoint, t);
        }
        else
        {
            pos = Vector3.Lerp(srcWorldPos, dstWorldPos, t);
        }
        // この3Dワールド座標が2Dカメラのキャンバス内でどこに来るのかを計算する
        var screenPos = _camera3d.WorldToScreenPoint(pos); // スクリーン座標に変換
        var ray = _camera2d.ScreenPointToRay(screenPos);
        effect.transform.position = ray.origin; // レイ上のどこを選んでも2Dならば同じなので、originを使う。
                                                // 遠くなら小さく描画する必要があるのでスケールを計算
        var camToPos = pos - _camera3d.transform.position;
        var zDistance = Vector3.Dot(_camera3d.transform.forward, camToPos)
            / _camera3d.transform.forward.magnitude;
        /* 内積で距離を求めるのが理解し難ければ、以下のようにしても良い。一旦ビュー座標に移し、そのzだけを見る。
		var zDistance = _camera3d.transform.worldToLocalMatrix.MultiplyPoint3x4(pos).z; //Zしか使わないので、ここの乗算は部分的に行うとより良い。
		*/
        // distance == _effectDstUiPlaneDistanceFromCameraの時に1で、distanceが2倍になればスケールは半分になる。よって割り算。
        var scale = effect.uiPlaneDistanceFromCamera / zDistance;
        effect.transform.localScale = new Vector3(scale, scale, scale);

        // 終了判定
        if (effect.time >= _effectDuration)
        {
            effect.transform.gameObject.SetActive(false);
        }
        effect.time += dt;
    }

    static void Bezier(out Vector3 pOut, ref Vector3 p0, ref Vector3 p1, ref Vector3 controlPoint, float t)
	{
		pOut = p1 - (controlPoint * 2f) + p0;
		pOut *= t;
		pOut += (controlPoint - p0) * 2f;
		pOut *= t;
		pOut += p0;
	}
}