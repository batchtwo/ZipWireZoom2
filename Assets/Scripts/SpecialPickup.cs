using UnityEngine;
using System.Collections;

public class SpecialPickup : MonoBehaviour 
{
	// Variables to make the pickup a public event, to trigger a speed boost in MoveWorld
	public delegate void PickupAction();
	public static event PickupAction OnPickup;

	void Update()
	{
		// Move towards the camera, with the static MoveSpeed variable from MoveWorld
		// This will then change accordingly during any speed changes
		transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - MoveWorld.MoveSpeed * Time.deltaTime );

		// Destroy the object once out of reach and view
		if (transform.position.z <= -10)
		{
			Destroy(gameObject);
		}

		// Rotate to make it seem ~TANTALISING~
		transform.Rotate(0, 2, 0);
	}

	// If player grabs pickup we:
	// Invoke the pickup event which will broadcast to MoveWorld
	// Increase time of day
	// Destroy the object
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			// invoke the event
			if (OnPickup != null)
				OnPickup();

			ScoreManager.timeOfDay += 0.1f;
			Destroy(gameObject, 0f);
		}
	}

}
