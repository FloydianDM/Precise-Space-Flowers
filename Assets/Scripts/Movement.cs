using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float thrustSpeed = 100f;
    [SerializeField] private float rotationSpeed = 20f;
    [SerializeField] AudioClip rocketBoostAudio;

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
            _rb.AddRelativeForce(Vector3.up * thrustSpeed * Time.deltaTime);

            if (!_audioSource.isPlaying)
            {
                _audioSource.PlayOneShot(rocketBoostAudio);
            }
        }
        else
        {
            _audioSource.Stop();
        }
    }

    private void ProcessRotation()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            _rb.freezeRotation = true; // freezing rotation to provide manual rotation.
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
            _rb.freezeRotation = false;
        }

        else if(Input.GetKey(KeyCode.RightArrow))
        {
            _rb.freezeRotation = true; // freezing rotation to provide manual rotation.
            transform.Rotate(Vector3.back * rotationSpeed * Time.deltaTime);
            _rb.freezeRotation = false;
        }
    }

}