using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToNextScene : MonoBehaviour
{
    [Header("Scene Settings")]
    [SerializeField] string nextSceneName;         // Name of the next scene to load
    [SerializeField] bool hasNextScene = true;        // Does the scene have a next scene?
    private string gameOverSceneName = "GameOver"; // Name of the Game Over scene to load
    private string newGameScene = "Level-1";


    public void ActivateNextScene()
    {
        if (!string.IsNullOrEmpty(nextSceneName) && hasNextScene)
        {
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            Debug.LogWarning("Next scene name is not set!");
        }
    }

    public void ActivateGameOverScene()
    {
        SceneManager.LoadScene(gameOverSceneName);
    }

    public void ActivateNewGameScene()
    {
        SceneManager.LoadScene(newGameScene);
    }
}
