using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRespawn : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))  // Check if the player touches the respawn object
        {
            RespawnPlayer();
        }

        RespawnPlayer();
    }

    void RespawnPlayer()
    {

        // GameObject player = GameObject.FindGameObjectWithTag("Player");

        // player.transform.position = new Vector3(-9, 0, 1);
        // transform.position = new Vector3(-9, 0, 1);

        SceneManager.LoadScene("tutorial");




    }
}

