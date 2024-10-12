using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateTrigger : MonoBehaviour
{
    // Reference to the object's Renderer

    private Renderer objectRenderer;

    // Color to change to on trigger
    public Color newColor = Color.red;

    // Original color to reset when exiting trigger
    private Color originalColor;

    void Start()
    {
        // Get the Renderer component
        objectRenderer = GetComponent<Renderer>();

        // Store the original color of the object
        originalColor = objectRenderer.material.color;
    }

    // Method triggered when another object enters the trigger zone
    void OnTriggerEnter(Collider other)
    {
        // Change the object's color to the new color
        objectRenderer.material.color = newColor;
    }

    // Method triggered when another object exits the trigger zone
    void OnTriggerExit(Collider other)
    {
        // Reset the object's color to the original color
        objectRenderer.material.color = originalColor;
    }
}
