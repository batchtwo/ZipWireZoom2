using UnityEngine;
using System.Collections;

public class PickupScript : MonoBehaviour 
{
	// Script for the standard pickup objects
	// Will simply update the z to move towards camera at a rate set by MoveWorld
	// Destroy the object if out of view
	// Hide the object's meshRenderer, play the sound and increase time of day if trigger is hit by player

	private AudioSource pickupAudio;
	private MeshRenderer meshRenderer;

	void Awake()
	{
		pickupAudio = GetComponent <AudioSource> ();
		meshRenderer = GetComponent <MeshRenderer> ();
	}

	void Update()
	{
		// Update position
		transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - MoveWorld.MoveSpeed * Time.deltaTime);

		// Destroy if out of view
		if (transform.position.z <= -10)
		{
			Destroy(gameObject);
		}

		// Rotate constantly
		transform.Rotate(0, 2, 0);
	}

	// If collected, increase time of day and then destroy
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			pickupAudio.Play();
			ScoreManager.timeOfDay += 0.008f;

			// Just hide mesh so audio still plays
			// Object will be deleted anyway once past camera
			meshRenderer.enabled = false;
		}
	}
}
