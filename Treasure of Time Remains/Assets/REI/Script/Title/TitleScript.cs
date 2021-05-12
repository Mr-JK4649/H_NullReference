using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScript : MonoBehaviour
{
    float count;
    float flg = 0;
    public GameObject fade;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            flg = 1;
            fade.SetActive(true);
        }

        if (flg == 1) count += Time.deltaTime;

        if (count >= 2) SceneMove();
    }
    void SceneMove()
    {
        SceneManager.LoadScene("StageSelect");
    }
}
