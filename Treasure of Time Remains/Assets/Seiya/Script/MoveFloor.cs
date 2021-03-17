using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chronos;

public class MoveFloor : MonoBehaviour
{
	private GlobalClock _GlobalClock;
	GameObject TimeKeeper;
	GlobalClock[] script = new GlobalClock[2];
	private Vector3 pos;
	public float movetime = 5f;

	void Start()
	{

		pos = transform.position;
		TimeKeeper = GameObject.Find("Timekeeper");
		script = TimeKeeper.GetComponents<GlobalClock>();
	}

	void Update()
	{
		//this.enabled = true;
		if (script[1].timeScale == 1)
		{
			//this.enabled = true;

			// Mathf.PingPong(float t, float length)　これの値を2倍や3倍にすることで移動速度上がる？;
			// movetimeの値を0からlengthの範囲内で行ったりきたりさせる。
			//this.gameObject.transform.position = new Vector3(pos.x + Mathf.PingPong(Time.time * 4, movetime), pos.y, pos.z);//x軸
			this.gameObject.transform.position = new Vector3(pos.x, pos.y + Mathf.PingPong(Time.time * 4, movetime), pos.z);//y軸移動
		}

		if (script[1].timeScale == 0)
		{
			//this.enabled = true;

			// Mathf.PingPong(float t, float length)　これの値を2倍や3倍にすることで移動速度上がる？;
			// movetimeの値を0からlengthの範囲内で行ったりきたりさせる。
			//this.gameObject.transform.position = new Vector3(pos.x + Mathf.PingPong(Time.time * 4, movetime), pos.y, pos.z);//x軸
			//this.gameObject.transform.position = new Vector3(pos.x, pos.y + Mathf.PingPong(Time.time * 4, movetime), pos.z);//y軸移動
		}
		//if (script.timeScale == 0)
		//{
		//	this.enabled = false;
		//}
	}
}
