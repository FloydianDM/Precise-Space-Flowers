using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    GameManager _gameManager;

    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Finish":
                Debug.Log("Finish");
                _gameManager.LoadNextLevel();
                break;
            case "Friendly":
                break;
            default:
                _gameManager.ReloadLevel();
                break;
        }
    }
}
