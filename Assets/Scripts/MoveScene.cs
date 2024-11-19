using UnityEngine;
using UnityEngine.SceneManagement;

public class PressurePlate : MonoBehaviour
{
    // Name of the scene to load
    public string sceneToLoad;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object is the player
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player stepped on the pressure plate! Loading scene...");
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
