using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;           // Speed of player movement
    public float jumpForce = 5f;           // Force applied for jumping
    public float mouseSensitivity = 100f;  // Mouse sensitivity for camera movement
    public Transform playerBody;           // Reference to the player's body for rotation
    public Transform groundCheck;          // Reference to an empty GameObject to check if player is grounded
    public LayerMask groundMask;           // LayerMask to specify what is considered ground

    private Rigidbody rb;
    private float xRotation = 0f;          // Track vertical rotation for the camera
    private bool isGrounded;               // Is the player grounded?

    public float groundDistance = 0.4f;    // Distance to the ground for ground checking

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Lock the cursor to the center of the screen and hide it
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Handle camera rotation with the mouse
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Clamp vertical camera rotation

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); // Rotate the camera vertically
        playerBody.Rotate(Vector3.up * mouseX); // Rotate player horizontally based on mouse X

        // Check if the player is grounded (use a sphere to detect the ground)
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // Handle player movement (forward, backward, left, right)
        float moveX = Input.GetAxis("Horizontal"); // A/D or Left/Right
        float moveZ = Input.GetAxis("Vertical");   // W/S or Up/Down

        Vector3 move = transform.right * moveX + transform.forward * moveZ; // Move in local player space
        rb.MovePosition(rb.position + move * moveSpeed * Time.deltaTime);

        // Handle jumping (spacebar)
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    // Optional: Visualize the ground check sphere in the editor
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundDistance);
    }
}
