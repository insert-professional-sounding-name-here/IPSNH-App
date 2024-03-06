using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyboardController : MonoBehaviour
{
    private TouchScreenKeyboard keyboard;

    void Start()
    {
        // Initialize the TouchScreenKeyboard
        keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
    }

    void Update()
    {
        // Check if the keyboard is active and visible
        if (keyboard != null && keyboard.active && keyboard.status != TouchScreenKeyboard.Status.Done)
        {
            // Update the text or perform other actions as needed
            string inputText = keyboard.text;
            Debug.Log("Input Text: " + inputText);
        }
    }
}

