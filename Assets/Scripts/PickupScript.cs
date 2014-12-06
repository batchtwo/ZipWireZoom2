﻿using UnityEngine;
using System.Collections;

public class PickupScript : MonoBehaviour 
{
	// Script for the standard pickup objects
	// Will simply update the z to move towards camera at a rate set by MoveWorld
	// Destroy the object if out of view
	// Destroy object and increase time of day if trigger is hit by player

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
			ScoreManager.timeOfDay += 0.008f;
			Destroy(gameObject, 0f);
		}
	}
}
