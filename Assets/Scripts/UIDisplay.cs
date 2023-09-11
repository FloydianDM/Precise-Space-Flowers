using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace PreciseSpaceFlowers
{
    public class UIDisplay : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private TextMeshProUGUI healthText;
        
        private Score _scorer;
        private Health _healthKeeper;
        
        private void Start()
        {
            _scorer = FindObjectOfType<Score>();
            _healthKeeper = FindObjectOfType<Health>();
        }

        private void Update()
        {
            DisplayScore();
            DisplayHealth();
        }

        private void DisplayScore()
        {
            scoreText.text = $"SCORE: {_scorer.GetScore()}";
        }

        private void DisplayHealth()
        {
            healthText.text = $"HEALTH: {_healthKeeper.GetHealth()}";
        }
    }
}


