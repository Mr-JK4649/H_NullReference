using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMoveManager : MonoBehaviour
{
    private enum SCENE { 
        TITLE,
        MAIN,
        RESULT,
        CLEAR,
        GAMEOVER
    }

    [SerializeField] private SCENE currentScene;

    [SerializeField] private string sceneName;

    private void Update()
    {
        

        switch (currentScene) {
            case SCENE.TITLE:
            case SCENE.RESULT:
            case SCENE.GAMEOVER:
                if (Input.GetButtonDown("Submit"))
                    SceneManager.LoadScene(sceneName);
                break;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
