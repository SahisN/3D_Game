using UnityEngine;

public class TrapReset : MonoBehaviour
{
    public GameObject[] traps; // Assign your trap GameObjects in the inspector
    public Vector3[] originalPositions; // Store the original positions of traps

    private void Start()
    {
        // Store original positions of the traps
        originalPositions = new Vector3[traps.Length];
        for (int i = 0; i < traps.Length; i++)
        {
            originalPositions[i] = traps[i].transform.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player has fallen
        if (other.CompareTag("Player"))
        {
            ResetTraps();
        }
    }

    private void ResetTraps()
    {
        // Reset the position of each trap
        for (int i = 0; i < traps.Length; i++)
        {
            traps[i].transform.position = originalPositions[i];
            // Optionally, reset any other trap states (e.g., animations)
        }
    }
}
