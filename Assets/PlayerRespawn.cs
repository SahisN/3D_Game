using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRespawn : MonoBehaviour
{
    //public Transform respawnPoint;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))  // Check if the player touches the respawn object
        {
            RespawnPlayer();
        }

        RespawnPlayer();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            RespawnPlayer();
        }
    }



    void RespawnPlayer()
    {

        // GameObject player = GameObject.FindGameObjectWithTag("Player");

        // player.transform.position = new Vector3(-9, 0, 1);
        // transform.position = new Vector3(-9, 0, 1);
       // transform.position = respawnPoint.position;

        // Optional: Reset velocity if using a Rigidbody
        //Rigidbody rb = GetComponent<Rigidbody>();
       // if (rb != null)
       // {
         //   rb.velocity = Vector3.zero;
          //  rb.angularVelocity = Vector3.zero;
       // }

        SceneManager.LoadScene("tutorial");




    }
}

