using UnityEngine;

public class Billboard : MonoBehaviour
{
	private Transform playerTransform;

	void Start()
	{
		// Find the player GameObject by its tag
		GameObject player = GameObject.FindGameObjectWithTag("Player");

		if (player != null)
		{
			playerTransform = player.transform;
		}
		else
		{
			Debug.LogError("Player with tag 'Player' not found in the scene.");
		}
	}

	void Update()
	{
		if (playerTransform != null)
		{
			// Calculate direction to the player
			Vector3 direction = playerTransform.position - transform.position;

			// Set rotation to look at the player with a 180-degree y-axis offset
			Quaternion lookRotation = Quaternion.LookRotation(direction);
			transform.rotation = lookRotation * Quaternion.Euler(0, 180, 0);
		}
	}
}
