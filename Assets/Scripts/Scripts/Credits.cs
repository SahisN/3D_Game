using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Credits : MonoBehaviour
{
    public float scrollSpeed = 10f; // Speed at which credits scroll
    public RectTransform creditsText; // Reference to the RectTransform of the credits text

    private void Update()
    {
        // Scroll the credits text upwards
        creditsText.Translate(Vector3.up * scrollSpeed * Time.deltaTime);
    }

    // Method to return to Main Menu
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
