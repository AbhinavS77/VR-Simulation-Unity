using UnityEngine;
using UnityEngine.UI;

public class Compass : MonoBehaviour
{
	public Transform player; // The player's transform
	public RectTransform compassNeedle; // The UI element for the compass needle
	public Text headingText; // The UI Text element to display the heading in degrees

	void Update()
	{
		// Get the player's current heading (yaw rotation)
		float playerHeading = player.eulerAngles.y;

		// Apply a 180-degree offset to adjust the compass direction
		float adjustedHeading = playerHeading - 180;
		if (adjustedHeading < 0) adjustedHeading += 360; // Keep it within 0-360 degrees

		// Update the compass needle rotation in the opposite direction
		compassNeedle.localEulerAngles = new Vector3(0, 0, adjustedHeading);

		// Determine the cardinal direction based on the adjusted heading
		string direction = GetCardinalDirection(adjustedHeading);

		// Update the heading text to display the adjusted heading in degrees and cardinal direction
		headingText.text = Mathf.RoundToInt(adjustedHeading) + "° " + direction;
	}

	private string GetCardinalDirection(float heading)
	{
		if (heading >= 358 || heading <= 2) return "N";
		if (heading >= 88 && heading <= 92) return "E";
		if (heading >= 178 && heading <= 182) return "S";
		if (heading >= 268 && heading <= 272) return "W";
		if (heading > 2 && heading < 88) return "NE";
		if (heading > 92 && heading < 178) return "SE";
		if (heading > 182 && heading < 268) return "SW";
		if (heading > 272 && heading < 358) return "NW";
		return ""; // Default to no cardinal direction if not within range
	}
}
