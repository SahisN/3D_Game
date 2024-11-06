using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Optional, only if you work with UI elements directly

public class MainMenu : MonoBehaviour
{
    // Load the Loading Screen scene or directly to the first level
    public void NewGame()
    {
        SceneManager.LoadScene("LoadingScreen"); // Replace with your loading screen or tutorial scene
    }

    // Open Settings Panel
    public GameObject settingsPanel;
    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
    }

    // Close Settings Panel
    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
    }

    // Open Credits Panel
    public GameObject creditsPanel;
    public void OpenCredits()
    {
        creditsPanel.SetActive(true);
    }

    // Close Credits Panel
    public void CloseCredits()
    {
        creditsPanel.SetActive(false);
    }

    // Quit the game
    public void QuitGame()
    {
        Application.Quit();
    }
}
