using System.Collections;
using System Collections Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ASyncLoader : MonoBehaviour
{
    public GameObject LoadingScreen;
    public Image LoadingBarfill;
    public Slider progressBar;
    public Text progressText;

    public void LoadScene(int sceneId)
    {
        StartCoroutine(LoadSceneAsync(sceneId));
    }

    IEnumerator LoadSceneAsync(int sceneId)
    {
        AsyncOperation operation = SceneManager LoadSceneAsync(sceneId);

        LoadingScreen SetActive(true);

        while (!operation isDone)
        {
            float progressValue = Mathf Clamp01(operation progress /0.9f);

            LoadingBarfill fillAmount = progressValue;

            yield return null;
        }
    }
    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneAsync(sceneName));
    }

    private IEnumerator LoadSceneAsync(string sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

        // Optional: Prevents the scene from displaying until fully loaded
        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            // Calculate progress (0.0f to 1.0f)
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            // Update the progress bar and text
            if (progressBar != null) progressBar.value = progress;
            if (progressText != null) progressText.text = (progress * 100).ToString("F0") + "%";

            // Activate the scene when loading is nearly complete
            if (operation.progress >= 0.9f)
            {
                operation.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}
