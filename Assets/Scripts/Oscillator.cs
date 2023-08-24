using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    [SerializeField] Vector3 movementVector; 
    [SerializeField] float period = 2f;

    float _movementFactor;
    Vector3 _startingPosition;
    

    // Start is called before the first frame update
    void Start()
    {
        _startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (period <= Mathf.Epsilon)
        {
            return;
        }

        float cycles = Time.time / period;
        const float tau = Mathf.PI * 2;
        float rawSinWave = Mathf.Sin(cycles * tau);

        _movementFactor = (rawSinWave + 1f) / 2f;

        Vector3 offset = movementVector * _movementFactor;
        transform.position = _startingPosition + offset; 
    }
}
