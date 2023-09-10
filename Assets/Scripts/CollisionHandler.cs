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
            if(!_movement.isCollisionEnabled)
            {
                return;
            }

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
}


