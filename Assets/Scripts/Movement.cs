using UnityEngine;

namespace PreciseSpaceFlowers
{
    public class Movement : MonoBehaviour
    {
        [SerializeField] private float thrustSpeed = 100f;
        [SerializeField] private float rotationSpeed = 20f;

        [SerializeField] AudioClip rocketBoostAudio;

        [SerializeField] ParticleSystem jetParticles;
        [SerializeField] ParticleSystem leftSideThrusterParticles;
        [SerializeField] ParticleSystem rightSideThrusterParticles;

        Rigidbody _rb;
        AudioSource _audioSource;
        GameManager _gameManager;
        public bool isCollisionEnabled = true;

        // Start is called before the first frame update
        void Start()
        {
            _rb = GetComponent<Rigidbody>();
            _audioSource = GetComponent<AudioSource>();
            _gameManager = FindObjectOfType<GameManager>();
        }

        // Update is called once per frame
        void Update()
        {
            ProcessThrust();
            ProcessRotation();
            DebugControls();
        }

        private void ProcessThrust()
        {
            if (Input.GetKey(KeyCode.Space))
            {
                AddThrust();
            }
            else
            {
                _audioSource.Stop();
                jetParticles.Stop();
            }
        }  

        private void ProcessRotation()
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                AddLeftRotation();
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                AddRightRotation();
            }
            else
            {
                rightSideThrusterParticles.Stop();
                leftSideThrusterParticles.Stop();
            }
        }

        private void AddThrust()
        {
            _rb.AddRelativeForce(thrustSpeed * Time.deltaTime * Vector3.up);

            if (!_audioSource.isPlaying)
            {
                _audioSource.PlayOneShot(rocketBoostAudio);
            }

            if (!jetParticles.isPlaying)
            {
                jetParticles.Play();
            }
        }

        private void AddLeftRotation()
        {
            _rb.freezeRotation = true; // freezing rotation to provide manual rotation.
            transform.Rotate(rotationSpeed * Time.deltaTime * Vector3.forward);
            _rb.freezeRotation = false;

            if (!rightSideThrusterParticles.isPlaying)
            {
                rightSideThrusterParticles.Play();
            }
        }

        private void AddRightRotation()
        {
            _rb.freezeRotation = true; // freezing rotation to provide manual rotation.
            transform.Rotate(rotationSpeed * Time.deltaTime * Vector3.back);
            _rb.freezeRotation = false;

            if (!leftSideThrusterParticles.isPlaying)
            {
                leftSideThrusterParticles.Play();
            }
        }

        private void DebugControls()
        {
            if (Input.GetKey(KeyCode.C))
            {
                isCollisionEnabled = !isCollisionEnabled;
            }

            if (Input.GetKey(KeyCode.L))
            {
                StartCoroutine(_gameManager.LoadNextLevel());
            }
        }
    }
}

