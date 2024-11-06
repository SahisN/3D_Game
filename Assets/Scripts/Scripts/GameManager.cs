using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public Transform spawnPoint;
    public Transform[] checkpoints;
    private int currentCheckpointIndex = -1;

    public GameObject[] traps;
    public Text healthText;
    public Text scoreText;

    private int playerHealth = 1;
    private int playerScore = 0;

    private bool isPaused = false;

    private void Start()
    {
        LoadSettings(); // Load player settings if needed
        UpdateHealthUI();
        UpdateScoreUI();
        LoadProgress(); // Load progress if you want to keep persistent player data
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    // Player health management
    public void TakeDamage(int damage)
    {
        playerHealth -= damage;
        UpdateHealthUI();

        if (playerHealth <= 0)
        {
            RespawnPlayer();
        }
    }

    private void UpdateHealthUI()
    {
        healthText.text = "Health: " + playerHealth;
    }

    // Player score management
    public void AddScore(int score)
    {
        playerScore += score;
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        scoreText.text = "Score: " + playerScore;
    }

    // Checkpoint management
    public void SetCheckpoint(int checkpointIndex)
    {
        if (checkpointIndex >= 0 && checkpointIndex < checkpoints.Length)
        {
            currentCheckpointIndex = checkpointIndex;
            SaveProgress(); // Optional: Save progress when hitting a checkpoint
        }
    }

    public void RespawnPlayer()
    {
        // If a checkpoint is set, respawn there, otherwise use the default spawn point
        if (currentCheckpointIndex >= 0)
        {
            player.transform.position = checkpoints[currentCheckpointIndex].position;
        }
        else
        {
            player.transform.position = spawnPoint.position;
        }

        playerHealth = 100; // Reset health on respawn
        UpdateHealthUI();
        ResetTraps();
    }

    private void ResetTraps()
    {
        foreach (GameObject trap in traps)
        {
            var trapBehavior = trap.GetComponent<TrapBehavior>();
            if (trapBehavior != null)
            {
                trapBehavior.ResetTrap();
            }
        }
    }

    // Save and load progress
    private void SaveProgress()
    {
        PlayerPrefs.SetInt("CheckpointIndex", currentCheckpointIndex);
        PlayerPrefs.SetInt("PlayerScore", playerScore);
    }

    private void LoadProgress()
    {
        if (PlayerPrefs.HasKey("CheckpointIndex"))
        {
            currentCheckpointIndex = PlayerPrefs.GetInt("CheckpointIndex");
            playerScore = PlayerPrefs.GetInt("PlayerScore");
            UpdateScoreUI();
        }
    }

    public void ResetProgress()
    {
        PlayerPrefs.DeleteAll();
        currentCheckpointIndex = -1;
        playerScore = 0;
        UpdateScoreUI();
    }

    // Pause management
    public void TogglePause()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0 : 1;
    }

    public void EndGame()
    {
        // Transition to the credits scene when the game is finished
        SceneManager.LoadScene("Credits");
    }
}
