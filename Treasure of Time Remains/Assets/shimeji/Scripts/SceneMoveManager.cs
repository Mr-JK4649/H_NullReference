using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMoveManager : MonoBehaviour
{
    private enum SCENE { 
        TITLE,
        MAIN,
        RESULT
    }

    [SerializeField] private SCENE currentScene;

    [SerializeField] private string sceneName;

    private void Update()
    {
        

        switch (currentScene) {
            case SCENE.TITLE:
            case SCENE.RESULT:
                if (Input.GetButtonDown("Submit"))
                    SceneManager.LoadScene(sceneName);
                break;

            case SCENE.MAIN:
                SceneManager.LoadScene(sceneName);
                break;
        }

    }
}
