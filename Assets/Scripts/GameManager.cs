using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PreciseSpaceFlowers
{
    public class GameManager : MonoBehaviour
    {   
        [Header ("Level Sound Effects")]
        [SerializeField] private AudioClip levelClearAudio;
        [SerializeField] private AudioClip crashAudio;
        
        [Header ("Particle Effects")]
        [SerializeField] private ParticleSystem levelClearParticle;
        [SerializeField] private ParticleSystem crashParticle;
        
        [Header ("Score Modifiers")]
        [SerializeField] private int reloadLevelScore = -10;
        [SerializeField] private int nextLevelScore = 50;
    
        private int _currentSceneIndex;
        private Movement _movement;
        private AudioSource _audioSource;
        private Score _scorer;
        
        void Start()
        {
            _movement = GetComponent<Movement>();
            _audioSource = GetComponent<AudioSource>();
            _scorer = GetComponent<Score>();
            _currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        }
    
        public IEnumerator ReloadLevel()
        {
            crashParticle.Play();
            _audioSource.PlayOneShot(crashAudio);
    
            _movement.enabled = false;
    
            yield return new WaitForSeconds(1);
    
            _audioSource.Stop();
            _movement.enabled = true;
            _scorer.AddScore(reloadLevelScore);
            SceneManager.LoadScene(_currentSceneIndex);
        }
    
        public IEnumerator LoadNextLevel()
        {
            levelClearParticle.Play();
            _audioSource.PlayOneShot(levelClearAudio);
    
            _movement.enabled = false;
    
            yield return new WaitForSeconds(1);
    
            _audioSource.Stop();
            _movement.enabled = true;
            _scorer.AddScore(nextLevelScore);
            if (_currentSceneIndex +1 == SceneManager.sceneCountInBuildSettings)
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
}


