using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObjectMarker : MonoBehaviour
{
	public string objectName; // The name to display above the object
	public GameObject player; // The player GameObject with the Player script
	public Canvas markerCanvas; // The Canvas for the marker
	public TextMeshProUGUI markerText; // The Text UI element to display the object name

	private Transform playerTransform; // Cached reference to the player's transform

	void Start()
	{
		// Get the player's transform from the Player script
		if (player != null)
		{
			playerTransform = player.transform;
		}
		else
		{
			player = FindAnyObjectByType<Player>().gameObject;
		}

		// Ensure the markerText is set
		if (markerText != null)
		{
			markerText.text = objectName;
		}
		else
		{
			Debug.LogError("Marker Text is not assigned.");
		}

		// Ensure the markerCanvas is set
		if (markerCanvas == null)
		{
			Debug.LogError("Marker Canvas is not assigned.");
		}
	}

	void Update()
	{
		// Make the marker face the player
		if (markerCanvas != null && playerTransform != null)
		{
			markerCanvas.transform.LookAt(playerTransform);
			markerCanvas.transform.Rotate(0, 180, 0); // Invert to face correctly
		}
	}
}
