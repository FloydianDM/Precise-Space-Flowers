using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int _currentSceneIndex;

    // Start is called before the first frame update
    void Start()
    { 
        _currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(_currentSceneIndex);
    }

    public void LoadNextLevel()
    {
        if (_currentSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            _currentSceneIndex++;
            SceneManager.LoadScene(_currentSceneIndex);
        } 
    }
}
