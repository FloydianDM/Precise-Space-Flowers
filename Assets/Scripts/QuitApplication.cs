using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PreciseSpaceFlowers
{
    public class QuitApplication : MonoBehaviour
    {
        private void OnQuit(InputValue input)
        {
            if (input.isPressed)
            {
                Debug.Log("Quit");
                Application.Quit();
            }
        }
    }
}


