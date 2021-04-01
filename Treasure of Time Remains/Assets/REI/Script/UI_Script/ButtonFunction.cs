using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunction : MonoBehaviour
{

	public void StringArgFunction(string s)
	{
		SceneManager.LoadScene(s);
		Time.timeScale = 1;
	}
}
