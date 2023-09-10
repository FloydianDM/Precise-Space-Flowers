using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PreciseSpaceFlowers
{
    public class Score : MonoBehaviour
    {
        private int _score;

        public void AddScore(int addedScore)
        {
            if (addedScore < 0)
            {
                if (_score < addedScore)
                {
                    _score = 0;
                }
                else
                {
                    _score += addedScore;
                }
            }
            else
            {
                _score += addedScore;
            }
        
        }
    }
}


