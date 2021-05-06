using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMoveManager : MonoBehaviour
{
    private enum SCENE
    {
        TITLE,
        MAIN,
        RESULT,
        CLEAR,
        GAMEOVER,
        OPENING,    //れい追加4/24
        ENDING      //れい追加4/24
    }

    [SerializeField] private SCENE currentScene;

    [SerializeField] private string sceneName;

    [SerializeField] private string[] nextSceneName;

    private void Update()
    {


        switch (currentScene)
        {
            case SCENE.TITLE:
            case SCENE.GAMEOVER:
                if (Input.GetButtonDown("Submit"))
                    SceneManager.LoadScene(sceneName);
                break;
            case SCENE.RESULT:
                if (Input.GetButtonDown("Submit"))
                {
                    //if (ScoreManager.Instance.StageNum == 3)
                    //    SceneManager.LoadScene("Title");
                    //else
                    //    SceneManager.LoadScene(sceneName);
                    SceneManager.LoadScene(nextSceneName[ScoreManager.Instance.StageNum]);
                }
                break;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}