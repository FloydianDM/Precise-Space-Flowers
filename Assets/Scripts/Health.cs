using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private int _health = 3;
    private static Health _instance;

    public int GetHealth()
    {
        return _health;
    }
    
    private void Awake()
    {
        ManageSingleton();
    }

    private void ManageSingleton()
    {
        if (_instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void LoseHealth()
    {
        _health--;
    }
    
}
