using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform bulletSpawnPosition;
    [SerializeField] float bulletSpeed = 2f;
    [SerializeField] AudioClip fireSound;
    
    readonly float _bulletLifetime = 10f;
    readonly float _timeToNextBullet = 0.5f;

    void Start()
    {
        ProcessFire();
    }
    
    void ProcessFire()
    {
        StartCoroutine(Fire());
    }

    private IEnumerator Fire()
    {
        while (true)
        {
            GameObject bulletInstance = Instantiate(bulletPrefab, bulletSpawnPosition.position, Quaternion.identity);
            Rigidbody rbBullet = bulletInstance.GetComponent<Rigidbody>();

            if (rbBullet != null)
            {
                rbBullet.AddForce(bulletSpeed * Vector3.left, ForceMode.Acceleration);
                bulletInstance.transform.Translate(-bulletSpeed * Time.deltaTime, 0, 0);
            }

            Destroy(bulletInstance, _bulletLifetime);

            yield return new WaitForSeconds(_timeToNextBullet);
        }   
    }
}
