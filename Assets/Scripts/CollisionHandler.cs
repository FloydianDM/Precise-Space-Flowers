using UnityEngine;

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
                StartCoroutine(_gameManager.LoadNextLevel());
                break;
            case "Friendly":
                break;
            default:
                StartCoroutine(_gameManager.ReloadLevel());
                break;
        }
    }
}
