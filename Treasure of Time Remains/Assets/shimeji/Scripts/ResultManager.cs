using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultManager : MonoBehaviour
{

    private void Update()
    {
        if (Input.GetButtonDown("Submit"))
            SceneManager.LoadScene("MainScene");

    }
}
