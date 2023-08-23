using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{   
    [SerializeField] AudioClip levelClearAudio;
    [SerializeField] AudioClip crashAudio;

    [SerializeField] ParticleSystem levelClearParticle;
    [SerializeField] ParticleSystem crashParticle;

    private int _currentSceneIndex;
    private Movement _movement;
    private AudioSource _audioSource;

    // Start is called before the first frame update
    void Start()
    {
        _movement = GetComponent<Movement>();
        _audioSource = GetComponent<AudioSource>();
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
