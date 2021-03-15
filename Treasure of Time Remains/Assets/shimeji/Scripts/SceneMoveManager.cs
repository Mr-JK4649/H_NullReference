using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMoveManager : MonoBehaviour
{
    [SerializeField] private string sceneName;

    private void Update()
    {
        if (Input.GetButtonDown("Submit"))
            SceneManager.LoadScene(sceneName);

    }
}
