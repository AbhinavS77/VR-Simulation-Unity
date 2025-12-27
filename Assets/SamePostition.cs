using UnityEngine;

public class SamePosition : MonoBehaviour
{
	[SerializeField] private Transform positionPoint;

	void Update()
	{
		// Match position exactly
		transform.position = positionPoint.position;

		// Get the target rotation but keep the local Z-axis rotation
		//Quaternion targetRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, positionPoint.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);

		//// Apply the new rotation
		//transform.rotation = targetRotation;
	}
}
