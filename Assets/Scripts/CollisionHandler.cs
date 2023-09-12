using UnityEngine;

namespace PreciseSpaceFlowers
{
    public class CollisionHandler : MonoBehaviour
    {
        GameManager _gameManager;
        Movement _movement;

        private void Awake()
        {
            _gameManager = FindObjectOfType<GameManager>();
            _movement = FindObjectOfType<Movement>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (!_movement.isCollisionEnabled && _gameManager.isTransitioning)
            {
                return;
            }

            switch (collision.gameObject.tag)
            {
                case "Finish":
                    _gameManager.isTransitioning = true; // transition starts
                    StartCoroutine(_gameManager.LoadNextLevel());
                    break;
                case "Friendly":
                    break;
                default:
                    _gameManager.isTransitioning = true; // transition starts
                    StartCoroutine(_gameManager.ReloadLevel());
                    break;
            }
        }
    } 
}


