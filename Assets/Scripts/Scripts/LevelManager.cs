using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    public GameObject loadingScreen; // Reference to the loading screen UI
    public UnityEngine.UI.Slider loadingBar; // Optional loading bar UI

    private string currentLevelName;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persist across scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start a new game from the main menu
    public void StartGame()
    {
        LoadLevel("Level1"); // Start at Level 1
    }

    // Load a specific level with async loading for smooth transitions
    public void LoadLevel(string levelName)
    {
        currentLevelName = levelName;
        StartCoroutine(LoadLevelAsync(levelName));
    }

    private IEnumerator LoadLevelAsync(string levelName)
    {
        if (loadingScreen != null) loadingScreen.SetActive(true);

        AsyncOperation operation = SceneManager.LoadSceneAsync(levelName);

        while (!operation.isDone)
        {
            if (loadingBar != null)
                loadingBar.value = operation.progress; // Update the loading bar if available

            yield return null;
        }

        if (loadingScreen != null) loadingScreen.SetActive(false);
    }

    // Load the next level in a series
    public void LoadNextLevel()
    {
        string[] levels = { "Level1", "Level2", "Level3" };
        int nextLevelIndex = System.Array.IndexOf(levels, currentLevelName) + 1;

        if (nextLevelIndex < levels.Length)
        {
            LoadLevel(levels[nextLevelIndex]);
        }
        else
        {
            EndGame(); // Go to credits when the final level is completed
        }
    }

    // End the game and transition to the credits scene
    public void EndGame()
    {
        SceneManager.LoadScene("Credits");
    }

    // Optional reset for progress between levels
    public void ResetGame()
    {
        currentLevelName = "Level1";
    }
}

