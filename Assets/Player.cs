using UnityEngine;
//using TMPro;

public class Player : MonoBehaviour
{
	public float moveSpeed = 5f;
	public float lookSpeed = 2f;
	public float jumpForce = 5f;
	public float verticalMoveSpeed = 5f; // Speed for vertical movement with Q and E
	public Camera playerCamera;

	private Rigidbody rb;
	private float rotationX = 0;
	//private TextMeshProUGUI txt;

	void Start()
	{
		//GameObject SpeedText = GameObject.Find("speed");
		//txt = SpeedText.GetComponent<TextMeshProUGUI>();

		rb = GetComponent<Rigidbody>();
		Cursor.lockState = CursorLockMode.Locked; // Lock the cursor to the game window
		Cursor.visible = false; // Hide the cursor
	}

	void Update()
	{
		HandleMovement();
		HandleLook();

		//txt.text = "Speed: " + rb.linearVelocity;
	}

	void HandleMovement()
	{
		// Get movement input
		float moveX = Input.GetAxis("Horizontal");
		float moveZ = Input.GetAxis("Vertical");

		// Calculate movement direction
		Vector3 move = transform.right * moveX + transform.forward * moveZ;

		// Vertical movement with Q and E
		float verticalMove = 0f;
		if (Input.GetKey(KeyCode.Q))
		{
			verticalMove = verticalMoveSpeed; // Move up
		}
		else if (Input.GetKey(KeyCode.E))
		{
			verticalMove = -verticalMoveSpeed; // Move down
		}

		// Update the Rigidbody's velocity
		rb.linearVelocity = new Vector3(move.x * moveSpeed, verticalMove, move.z * moveSpeed);

		// Jump
		if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb.linearVelocity.y) < 0.1f)
		{
			rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
		}
	}

	void HandleLook()
	{
		// Get mouse input
		float mouseX = Input.GetAxis("Mouse X") * lookSpeed;
		float mouseY = Input.GetAxis("Mouse Y") * lookSpeed;

		// Rotate the camera up/down (pitch)
		rotationX -= mouseY;
		rotationX = Mathf.Clamp(rotationX, -90f, 90f); // Limit vertical rotation
		playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);

		// Rotate the player left/right (yaw)
		transform.Rotate(Vector3.up * mouseX);
	}
}
