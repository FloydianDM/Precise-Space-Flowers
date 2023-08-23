using UnityEngine;

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

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    private void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            _rb.AddRelativeForce(thrustSpeed * Time.deltaTime * Vector3.up);

            if (!_audioSource.isPlaying)
            {
                _audioSource.PlayOneShot(rocketBoostAudio);
            }

            if(!jetParticles.isPlaying)
            {
                jetParticles.Play();
            }   
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
            _rb.freezeRotation = true; // freezing rotation to provide manual rotation.
            transform.Rotate(rotationSpeed * Time.deltaTime * Vector3.forward);
            if (!rightSideThrusterParticles.isPlaying)
            {
                rightSideThrusterParticles.Play();
            }
            _rb.freezeRotation = false;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            _rb.freezeRotation = true; // freezing rotation to provide manual rotation.
            transform.Rotate(rotationSpeed * Time.deltaTime * Vector3.back);
            if (!leftSideThrusterParticles.isPlaying)
            {
                leftSideThrusterParticles.Play();
            }
            _rb.freezeRotation = false;
        }
        else
        {
            rightSideThrusterParticles.Stop();
            leftSideThrusterParticles.Stop();
        }
    }

}